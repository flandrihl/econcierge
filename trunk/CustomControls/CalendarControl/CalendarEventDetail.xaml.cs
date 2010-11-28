using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using CustomControls.Abstract;
using CustomControls.TouchCombo;
using eConcierge.Business;
using eConcierge.Model;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.CalendarControl
{
    /// <summary>
    /// Interaction logic for CalendarEventDetail.xaml
    /// </summary>
    public partial class CalendarEventDetail : LocationControl, IMTouchControl
    {
        private List<DTOCalendarEvent> _events;
        private int _currentPagerIndex;
        public IMTContainer Container { get; set; }
        protected IFrameworkManger FrameworkManager { get; set; }
        public event EventHandler Closed;
        public int CategoryId { get; set; }
        
        public CalendarEventDetail()
        {
            InitializeComponent();
            categoryCombo.SelectionChanged += ComboItemsSelectionChanged;
            pager.ValueChanged += SldValueChanged;
            closeButton.Click += CloseButtonClick;
            mapDirectionsButton.Click += MapDirectionsButtonClick;
        }

        private void MapDirectionsButtonClick(object sender, RoutedEventArgs e)
        {
            InvokeShowDirections(new DataEventArgs(_calendarEvent));
        }

        public void InitializeControl(IFrameworkManger frameworkManager, double left, double top)
        {
            FrameworkManager = frameworkManager;
            FrameworkManager.RegisterElement((IMTouchControl)closeButton, true, null);
            FrameworkManager.RegisterElement((IMTouchControl)pager, false, new[] { TouchAction.Slide, TouchAction.Tap });
            categoryCombo.Initialize(FrameworkManager, GetCategoryComboItems());
            FrameworkManager.AddControlWithAllGestures(this, left, top);
            FrameworkManager.RegisterElement((IMTouchControl)mapDirectionsButton, false, new[] { TouchAction.Tap });
            categoryCombo.SelectedItem = CategoryId.ToString();
            SetEventProperties();
        }

        private static List<TouchComboBoxItem> GetCategoryComboItems()
        {
            var categoryComboItems = new List<TouchComboBoxItem>();
            var service = new EventCalendarCategoryService();
            var categoryList = service.GetEventCalendarCategorys();
            foreach (var category in categoryList)
            {
                var categoryComboItem = new TouchComboBoxItem();
                categoryComboItem.DisplayText = category.Name;
                categoryComboItem.Item = category.Id;
                categoryComboItems.Add(categoryComboItem);
            }
            return categoryComboItems;
        }

        public void Close()
        {
            FrameworkManager.UnRegisterElement(pager);
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.UnRegisterElement(mapDirectionsButton);
            FrameworkManager.RemoveControl(this);
            if(Closed!=null)
                Closed(this,new EventArgs());

        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        
        void SldValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newValue = Convert.ToInt32(e.NewValue);
            if(newValue == _currentPagerIndex + 1 || newValue == _currentPagerIndex-1)
            {
                _currentPagerIndex = newValue;
                SetEventProperties(_events[newValue]);    
            }
        }

        void ComboItemsSelectionChanged(object sender, DataEventArgs dataEventArgs)
        {
            SetEventProperties();
        }

        private void SetEventProperties()
        {
            var service = new CalendarEventService();
            _events = service.GetCalendarEvents(Convert.ToInt32(categoryCombo.SelectedItem));
            if (_events.Count > 0)
            {
                _currentPagerIndex = 0;
                pager.Minimum = 0;
                pager.Maximum = _events.Count - 1;
                pager.Value = 0;
                SetEventProperties(_events[0]);
            }
        }

        public BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }

        private void SetEventProperties(DTOCalendarEvent evnt)
        {
            _calendarEvent = evnt;
            imgEvent.Source = ImageFromBuffer(evnt.Photo);
            txbTitle.Text = evnt.Title;
            txbDescription.Text = string.Format("{0}{1}Event {2}-{3}{4}{5}", evnt.Description, Environment.NewLine, evnt.StartDate, evnt.EndDate, Environment.NewLine, evnt.Location);
        }

        private int _totalDays;
        private DateTime _eventDate;
        private DTOCalendarEvent _calendarEvent;

        public DateTime EventDate
        {
            set
            {
                txbDate.Text = value.Day.ToString();
                _eventDate = value;
                _totalDays = DateTime.DaysInMonth(value.Year, value.Month);
            }
            get
            {
                return _eventDate = new DateTime(_eventDate.Year, _eventDate.Month, Convert.ToInt32(txbDate.Text));
            }
        }

        private void BtnLeftEventDetailCategoryClick(object sender, RoutedEventArgs e)
        {
            int cDay = Convert.ToInt32(txbDate.Text);
            cDay--;
            SetDay(cDay);
            SetEventProperties();
        }

        private void BtnRightDetailEventCategoryClick(object sender, RoutedEventArgs e)
        {
            int cDay = Convert.ToInt32(txbDate.Text);
            cDay++;
            SetDay(cDay);
            SetEventProperties();
        }

        private void SetDay(int cDay)
        {
            btnLeftEventDetailCategory.IsEnabled = cDay != 1;
            btnRightDetailEventCategory.IsEnabled = cDay != _totalDays;
            txbDate.Text = cDay.ToString();
        }
    }
}

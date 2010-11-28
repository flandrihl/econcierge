using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CustomControls.Abstract;
using CustomControls.InheritedFrameworkControls;
using CustomControls.OptionControl;
using eConcierge.Business;
using eConcierge.Model;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Dining
{
    /// <summary>
    /// Interaction logic for CalendarControl.xaml
    /// </summary>
    public partial class DiningControl : LocationControl, IMTouchControl
    {
        private static DiningControl _dining;
        private List<TouchButton> _eventButtons;
        private const int NoOfItemInColumn = 4;
        public IFrameworkManger FrameworkManager { get; set; }
        private readonly List<DiningSubCateogryControl> _diningSubcategories=new List<DiningSubCateogryControl>();
        private readonly List<DiningDetail> _diningDetailControls = new List<DiningDetail>();

        public event EventHandler Closed;


        public static DiningControl GetInstance()
        {
            return _dining ?? (_dining = new DiningControl());
        }

        #region Properties
        
        public IMTContainer Container { get; set; }

        #endregion

        private DiningControl()
        {
            InitializeComponent();
            closeButton.Click += CloseButtonClick;
            PopulateEventCategory();
        }


        public void Load(IFrameworkManger frameworkManager, double left, double top)
        {
            FrameworkManager = frameworkManager;
            foreach (TouchButton eventButton in _eventButtons)
            {
                FrameworkManager.RegisterElement(eventButton as IMTouchControl, false, new[] { TouchAction.Tap });
            }
            FrameworkManager.RegisterElement((IMTouchControl)closeButton, false, new[] { TouchAction.Tap });
            FrameworkManager.AddControlWithAllGestures(this, left, top);
        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public void Close()
        {
            foreach (var eventButton in _eventButtons)
            {
                FrameworkManager.UnRegisterElement(eventButton);
            }
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.RemoveControl(this);
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        public void CloseWithChildren()
        {
            foreach (var eventButton in _eventButtons)
            {
                FrameworkManager.UnRegisterElement(eventButton);
            }
            FrameworkManager.UnRegisterElement(closeButton);
            foreach (var diningSubCateogryControl in _diningSubcategories.ToArray())
            {
                diningSubCateogryControl.Close();
            }
            foreach (var diningDetailControl in _diningDetailControls.ToArray())
            {
                diningDetailControl.Close();
            }
            FrameworkManager.RemoveControl(this);
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        private void PopulateEventCategory()
        {
            _eventButtons = new List<TouchButton>();
            var service = new EventCalendarCategoryService();
            List<DTOEventCalendarCategory> categoryList = service.GetEventCalendarCategorys();
            int col = -1, row = 0;

            foreach (var category in categoryList)
            {
                if (grdCategory.RowDefinitions.Count < NoOfItemInColumn)
                {
                    grdCategory.RowDefinitions.Add(new RowDefinition());
                }
                if (row == 0)
                {
                    grdCategory.ColumnDefinitions.Add(new ColumnDefinition());
                    col++;
                }
                var item = new TouchOptionItem();
                item.CategoryText = category.Name;
                item.CateogoryButton.Tag = category.Id;
                grdCategory.Children.Add(item);
                item.SetValue(Grid.ColumnProperty, col);
                item.SetValue(Grid.RowProperty, row);
                item.Margin = new Thickness(15, 10, 15, 10);
                _eventButtons.Add(item.CateogoryButton);
                item.CateogoryButton.Click += CateogoryButtonClick;
                row++;
                if (row == NoOfItemInColumn) row = 0;
            }
        }

        void CateogoryButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (TouchButton)sender;
            if (button == null) return;
            var categoryId = button.Tag.ToString();
            var control = new DiningSubCateogryControl();
            control.Closed += DiningSubcategoryClosed;
            control.DetailControlAdded += ControlDetailControlAdded;
            _diningSubcategories.Add(control);
            control.InitializeControl(FrameworkManager, categoryId);
        }

        void ControlDetailControlAdded(object sender, DataEventArgs e)
        {
            var diningDetail = e.Data as DiningDetail;
            diningDetail.Closed += DiningDetailClosed;
            _diningDetailControls.Add(diningDetail);
            diningDetail.ShowDirections += ShowDirectionsSelected;
        }

        void ShowDirectionsSelected(object sender, DataEventArgs e)
        {
            InvokeShowDirections(e);
        }

        void DiningDetailClosed(object sender, EventArgs e)
        {
            _diningDetailControls.Remove((DiningDetail) sender);
        }

        void DiningSubcategoryClosed(object sender, EventArgs e)
        {
            _diningSubcategories.Remove((DiningSubCateogryControl) sender);
        }
    }
}

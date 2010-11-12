using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CustomControls.Abstract;
using DataAccessLayer;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Atm
{
    /// <summary>
    /// Interaction logic for CalendarControl.xaml
    /// </summary>
    public partial class AtmControl : AnimatableControl, IMTouchControl
    {
        private static AtmControl _atm;
        private List<AtmItem> _atmItems;
        private readonly List<AtmDetail> _atmDetails=new List<AtmDetail>();
        private const int NoOfItemsPerColumn = 2;
        private IFrameworkManger FrameworkManager { get; set; }
        public event EventHandler Closed;
        public IMTContainer Container { get; set; }

        public static AtmControl GetInstance()
        {
            return _atm ?? (_atm = new AtmControl());
        }

        #region Properties

        #endregion

        private AtmControl()
        {
            InitializeComponent();
            closeButton.Click += CloseButtonClick;
            PopulatePointOfInterests();
            Slider.ValueChanged += SliderValueChanged;
            Loaded += AtmControlLoaded;
        }

        void AtmControlLoaded(object sender, RoutedEventArgs e)
        {
            Slider.Minimum = 0;
            Slider.Maximum = contentScroller.ExtentWidth-contentScroller.ActualWidth;
        }

        void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            contentScroller.ScrollToHorizontalOffset(e.NewValue);
        }


        public void Load(IFrameworkManger frameworkManager, double left, double top)
        {
            FrameworkManager = frameworkManager;
            foreach (var landMarkItem in _atmItems)
            {
                FrameworkManager.RegisterElement(landMarkItem as IMTouchControl, false, new[] { TouchAction.Tap });
            }
            FrameworkManager.RegisterElement((IMTouchControl)Slider, false, new[] { TouchAction.Slide });
            FrameworkManager.RegisterElement((IMTouchControl)closeButton, false, new[] { TouchAction.Tap });
            FrameworkManager.AddControlWithAllGestures(this, left, top);
        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public void Close()
        {
            foreach (var landMarkItem in _atmItems)
            {
                FrameworkManager.UnRegisterElement(landMarkItem);
            }
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.UnRegisterElement(Slider);
            FrameworkManager.RemoveControl(this);
            foreach (var landMarkDetail in _atmDetails.ToArray())
            {
                landMarkDetail.Close();
            }
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        private void PopulatePointOfInterests()
        {
            _atmItems = new List<AtmItem>();
            var atms = LandMarkDAL.GetInstance().GetLandMarks();
            int col = -1, row = 0;

            foreach (var atm in atms)
            {
                if (grdCategory.RowDefinitions.Count < NoOfItemsPerColumn)
                {
                    grdCategory.RowDefinitions.Add(new RowDefinition());
                }
                if (row == 0)
                {
                    grdCategory.ColumnDefinitions.Add(new ColumnDefinition());
                    col++;
                }
                var item = new AtmItem(atm);
                grdCategory.Children.Add(item);
                item.SetValue(Grid.ColumnProperty, col);
                item.SetValue(Grid.RowProperty, row);
                item.Margin = new Thickness(15, 10, 15, 10);
                _atmItems.Add(item);
                item.Click += AtmButtonClick;
                row++;
                if (row == NoOfItemsPerColumn) row = 0;
            }
        }

        void AtmButtonClick(object sender, EventArgs eventArgs)
        {
            var atmItem = (AtmItem)sender;
            var control = new AtmDetail(atmItem.LandMark);
            _atmDetails.Add(control);
            var top = FrameworkManager.Canvas.ActualHeight / 2 - (control.Height / 2);
            var left = FrameworkManager.Canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += AtmDetailClosed;   
        }

        private void AtmDetailClosed(object sender, EventArgs e)
        {
            _atmDetails.Remove((AtmDetail) sender);
        }
    }
}

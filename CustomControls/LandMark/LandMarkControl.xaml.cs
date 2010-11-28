using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CustomControls.Abstract;
using eConcierge.Business;
using Infrasturcture.Global.Helpers.Events;
using Infrasturcture.TouchLibrary;

namespace CustomControls.LandMark
{
    /// <summary>
    /// Interaction logic for CalendarControl.xaml
    /// </summary>
    public partial class LandMarkControl : LocationControl, IMTouchControl
    {
        private static LandMarkControl _dining;
        private List<LandMarkItem> _landMarkItems;
        private readonly List<LandMarkDetail> _landMarkDetails=new List<LandMarkDetail>();
        private const int NoOfItemsPerColumn = 2;
        public IFrameworkManger FrameworkManager { get; set; }
        public event EventHandler Closed;
        public IMTContainer Container { get; set; }

        public static LandMarkControl GetInstance()
        {
            return _dining ?? (_dining = new LandMarkControl());
        }

        #region Properties

        #endregion

        private LandMarkControl()
        {
            InitializeComponent();
            closeButton.Click += CloseButtonClick;
            PopulatePointOfInterests();
            Slider.ValueChanged += SliderValueChanged;
            Loaded += LandMarkControlLoaded;
        }

        void LandMarkControlLoaded(object sender, RoutedEventArgs e)
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
            foreach (var landMarkItem in _landMarkItems)
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
            foreach (var landMarkItem in _landMarkItems)
            {
                FrameworkManager.UnRegisterElement(landMarkItem);
            }
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.UnRegisterElement(Slider);
            FrameworkManager.RemoveControl(this);
            foreach (var landMarkDetail in _landMarkDetails.ToArray())
            {
                landMarkDetail.Closed -= LandMarkDetailClosed;
                landMarkDetail.ShowDirections -= ShowDirectionsSelected;
                landMarkDetail.Close();
            }
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        private void PopulatePointOfInterests()
        {
            _landMarkItems = new List<LandMarkItem>();
            var service = new PointOfInterestService();
            var landMarks = service.GetPointOfInterests();
            int col = -1, row = 0;

            foreach (var landmark in landMarks)
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
                var item = new LandMarkItem(landmark);
                grdCategory.Children.Add(item);
                item.SetValue(Grid.ColumnProperty, col);
                item.SetValue(Grid.RowProperty, row);
                item.Margin = new Thickness(15, 10, 15, 10);
                _landMarkItems.Add(item);
                item.Click += LandMarkButtonClick;
                row++;
                if (row == NoOfItemsPerColumn) row = 0;
            }
        }

        void LandMarkButtonClick(object sender, EventArgs eventArgs)
        {
            var landMarkItem = (LandMarkItem)sender;
            var control = new LandMarkDetail(landMarkItem.LandMark);
            _landMarkDetails.Add(control);
            var top = FrameworkManager.Canvas.ActualHeight / 2 - (control.Height / 2);
            var left = FrameworkManager.Canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += LandMarkDetailClosed;
            control.ShowDirections += ShowDirectionsSelected;
        }

        void ShowDirectionsSelected(object sender, DataEventArgs e)
        {
            InvokeShowDirections(e);
        }

        private void LandMarkDetailClosed(object sender, EventArgs e)
        {
            _landMarkDetails.Remove((LandMarkDetail) sender);
        }
    }
}

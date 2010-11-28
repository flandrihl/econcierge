using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CustomControls.Abstract;
using eConcierge.Business;
using Infrasturcture.TouchLibrary;

namespace CustomControls.Mall
{
    /// <summary>
    /// Interaction logic for CalendarControl.xaml
    /// </summary>
    public partial class MallControl : LocationControl, IMTouchControl
    {
        private static MallControl _mall;
        private List<MallItem> _mallItems;
        private readonly List<MallDetail> _mallDetails=new List<MallDetail>();
        private const int NoOfItemsPerColumn = 2;
        private IFrameworkManger FrameworkManager { get; set; }
        public event EventHandler Closed;
        public IMTContainer Container { get; set; }

        public static MallControl GetInstance()
        {
            return _mall ?? (_mall = new MallControl());
        }

        #region Properties

        #endregion

        private MallControl()
        {
            InitializeComponent();
            closeButton.Click += CloseButtonClick;
            PopulatePointOfInterests();
            Slider.ValueChanged += SliderValueChanged;
            Loaded += MallControlLoaded;
        }

        void MallControlLoaded(object sender, RoutedEventArgs e)
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
            foreach (var mallItem in _mallItems)
            {
                FrameworkManager.RegisterElement(mallItem as IMTouchControl, false, new[] { TouchAction.Tap });
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
            foreach (var mallItem in _mallItems)
            {
                FrameworkManager.UnRegisterElement(mallItem);
            }
            FrameworkManager.UnRegisterElement(closeButton);
            FrameworkManager.UnRegisterElement(Slider);
            FrameworkManager.RemoveControl(this);
            foreach (var landMarkDetail in _mallDetails.ToArray())
            {
                landMarkDetail.Close();
            }
            if (Closed != null)
                Closed(this, new EventArgs());
        }

        private void PopulatePointOfInterests()
        {
            _mallItems = new List<MallItem>();
            var service = new MallService();
            var malls = service.GetMalls();
            int col = -1, row = 0;

            foreach (var mall in malls)
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
                var item = new MallItem(mall);
                grdCategory.Children.Add(item);
                item.SetValue(Grid.ColumnProperty, col);
                item.SetValue(Grid.RowProperty, row);
                item.Margin = new Thickness(15, 10, 15, 10);
                _mallItems.Add(item);
                item.Click += MallButtonClick;
                row++;
                if (row == NoOfItemsPerColumn) row = 0;
            }
        }

        void MallButtonClick(object sender, EventArgs eventArgs)
        {
            var atmItem = (MallItem)sender;
            var control = new MallDetail(atmItem.Mall);
            _mallDetails.Add(control);
            var top = FrameworkManager.Canvas.ActualHeight / 2 - (control.Height / 2);
            var left = FrameworkManager.Canvas.ActualWidth / 2 - (control.Width / 2);
            control.Load(FrameworkManager, left, top);
            control.Closed += MallDetailClosed;   
        }

        private void MallDetailClosed(object sender, EventArgs e)
        {
            _mallDetails.Remove((MallDetail) sender);
        }
    }
}

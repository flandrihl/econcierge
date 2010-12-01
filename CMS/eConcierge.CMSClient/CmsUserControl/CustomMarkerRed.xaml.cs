using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using eConcierge.CMSClient.CmsWindow;
using GMap.NET.WindowsPresentation;

namespace Demo.WindowsPresentation.CustomMarkers
{
    /// <summary>
    /// Interaction logic for CustomMarkerDemo.xaml
    /// </summary>
    public partial class CustomMarkerRed
    {
        Popup Popup;
        Label Label;
        GMapMarker Marker;
        wndGmap MainWindow;

        public CustomMarkerRed(wndGmap window, GMapMarker marker, string title)
        {
            this.InitializeComponent();

            this.MainWindow = window;
            this.Marker = marker;

            Popup = new Popup();
            Label = new Label();

            this.Loaded += new RoutedEventHandler(CustomMarkerDemoLoaded);
            //this.SizeChanged += new SizeChangedEventHandler(CustomMarkerDemo_SizeChanged);
            this.MouseEnter += new MouseEventHandler(MarkerControl_MouseEnter);
            this.MouseLeave += new MouseEventHandler(MarkerControl_MouseLeave);
            //this.MouseMove += new MouseEventHandler(CustomMarkerDemo_MouseMove);
            //this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonUp);
            //this.MouseLeftButtonDown += new MouseButtonEventHandler(CustomMarkerDemo_MouseLeftButtonDown);

            Popup.Placement = PlacementMode.Mouse;
            {
                Label.Background = Brushes.Transparent;
                Label.Foreground = Brushes.DarkRed;
                Label.BorderBrush = Brushes.Transparent;
                Label.BorderThickness = new Thickness(0);
                Label.Padding = new Thickness(0);
                Label.FontSize = 22;
                Label.Content = title;
            }
            Popup.AllowsTransparency = true;
            Popup.Child = Label;
        }

        void CustomMarkerDemoLoaded(object sender, RoutedEventArgs e)
        {
            if (icon.Source.CanFreeze)
            {
                icon.Source.Freeze();
            }
        }

        void CustomMarkerDemo_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Marker.Offset = new Point(-e.NewSize.Width / 2, -e.NewSize.Height);
        }

        void CustomMarkerDemo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && IsMouseCaptured)
            {
                Point p = e.GetPosition(MainWindow.MainMap);
               // Marker.Position = MainWindow.MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            }
        }

        void CustomMarkerDemo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseCaptured)
            {
               // Mouse.Capture(this);
            }
        }

        void CustomMarkerDemo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
               // Mouse.Capture(null);
            }
        }

        void MarkerControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Marker.ZIndex -= 10000;
            Popup.IsOpen = false;
        }

        void MarkerControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Marker.ZIndex += 10000;
            Popup.IsOpen = true;
        }
    }
}
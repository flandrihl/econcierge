using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Demo.WindowsPresentation.CustomMarkers;
using GMap.NET;
using GMap.NET.WindowsPresentation;

namespace eConcierge.CMSClient.CmsWindow
{
    /// <summary>
    /// Interaction logic for wndGmap.xaml
    /// </summary>
    public partial class wndGmap : Window
    {
        private Point oldPosition;

        // marker
        GMapMarker currentMarker;

        public wndGmap()
        {
            InitializeComponent();
            // config map
           
            MainMap.MouseLeftButtonDown += new MouseButtonEventHandler(MainMap_MouseLeftButtonDown);
            MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);

            // set current marker
            
            
        }

        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
               if(oldPosition != null)
               {
                   var newPosition = e.GetPosition(MainMap);
                   MainMap.Offset((int)(oldPosition.X - newPosition.X), (int)(oldPosition.Y - newPosition.Y));
               }
            }
            var p = e.GetPosition(MainMap);
            oldPosition = p;
        }

        public double Latitude
        {
            set
            {
                txbLatitude.Text = value.ToString();
            }
            get
            {
                return Convert.ToDouble(txbLatitude.Text);
            }
        }
        public double Longitude
        {
            set
            {
                txbLongitude.Text = value.ToString();
            }
            get
            {
                return Convert.ToDouble(txbLongitude.Text);
            }
        }
        void MainMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(MainMap);
            var latlong = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            Latitude = latlong.Lat;
            Longitude = latlong.Lng;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public void InitializeLatLng(double lat = 54.6961334816182, double lng = 25.2985095977783)
        {
            MainMap.Position = new PointLatLng(lat, lng);
            Latitude = lat;
            Longitude = lng;
            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new CustomMarkerRed(this, currentMarker, "custom position marker");
                currentMarker.Offset = new System.Windows.Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
                MainMap.Markers.Add(currentMarker);
            }
            currentMarker.Position = new PointLatLng(lat, lng);
        }
    }
}

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
        private PointLatLng _hotelPosition;

        public wndGmap()
        {
            InitializeComponent();
            // config map
            WindowState = WindowState.Maximized;
           
            MainMap.MouseLeftButtonDown += MainMapMouseLeftButtonDown;
            MainMap.MouseMove += MainMapMouseMove;

            // set current marker
            
            
        }

        void MainMapMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
               if(oldPosition != null)
               {
                   var newPosition = e.GetPosition(MainMap);
                   MainMap.Offset((int)-(oldPosition.X - newPosition.X), (int)-(oldPosition.Y - newPosition.Y));
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
        void MainMapMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(MainMap);
            var latlong = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            Latitude = latlong.Lat;
            Longitude = latlong.Lng;
        }

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public void InitializeLatLng(string hotelName, double lat = 41.850033, double lng = -87.6500523)
        {
            _hotelPosition = new PointLatLng(lat, lng);
            MainMap.Position = _hotelPosition;
            Latitude = lat;
            Longitude = lng;
            //currentMarker = new GMapMarker(MainMap.Position);
            //{
            //    currentMarker.Shape = new CustomMarkerRed(this, currentMarker, hotelName);
            //    currentMarker.Offset = new Point(-15, -15);
            //    currentMarker.ZIndex = int.MaxValue;
            //    MainMap.Markers.Add(currentMarker);
            //}
            //currentMarker.Position = new PointLatLng(lat, lng);
        }

        private void FocusHotel()
        {
            //MainMap.Position = currentMarker.Position;
            MainMap.Zoom = 14;
        }

        private void BtnShowHotelClick(object sender, RoutedEventArgs e)
        {
            FocusHotel();
        }
    }
}

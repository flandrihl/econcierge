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
using System.Windows.Navigation;
using System.Windows.Shapes;
using eConcierge.Business;
using eConcierge.CMSClient.CmsWindow;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for ATMDetail.xaml
    /// </summary>
    public partial class HotelDetail : UserControlBase
    {
        private HotelService _service;

        #region Properties
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(HotelDetail));

        public string HotelName
        {
            get { return (string)GetValue(HotelNameProperty); }
            set { SetValue(HotelNameProperty, value); }
        }

        public static readonly DependencyProperty HotelNameProperty =
            DependencyProperty.Register("HotelName", typeof(string), typeof(HotelDetail));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(HotelDetail));

        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }

        public static readonly DependencyProperty PhoneProperty =
            DependencyProperty.Register("Phone", typeof(string), typeof(HotelDetail));

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address", typeof(string), typeof(HotelDetail));

        public Visibility EditStateVisibility
        {
            get { return (Visibility)GetValue(EditStateVisibilityProperty); }
            set { SetValue(EditStateVisibilityProperty, value); }
        }

        public static readonly DependencyProperty EditStateVisibilityProperty =
            DependencyProperty.Register("EditStateVisibility", typeof(Visibility), typeof(HotelDetail));

        public Visibility ReadOnlyStateVisibility
        {
            get { return (Visibility)GetValue(ReadOnlyStateVisibilityProperty); }
            set { SetValue(ReadOnlyStateVisibilityProperty, value); }
        }

        public static readonly DependencyProperty ReadOnlyStateVisibilityProperty =
            DependencyProperty.Register("ReadOnlyStateVisibility", typeof(Visibility), typeof(HotelDetail));
        #endregion

        public HotelDetail()
        {
            this.DataContext = this;
            InitializeComponent();
            PrepareView();

            locationControl.lblLatitude.Foreground = Brushes.White;
            locationControl.lblLongitude.Foreground = Brushes.White;
            
        }
        
        private void PrepareView()
        {
            var hotelDetail = Service.GetHotelDetails();
            if (hotelDetail != null)
            {
                Id = hotelDetail.Id;
                HotelName = hotelDetail.HotelName;
                Description = hotelDetail.Description;
                Phone = hotelDetail.Phone;
                Address = hotelDetail.Address;
                locationControl.txtLatitude.Text = hotelDetail.Latitude.ToString();
                locationControl.txtLongitude.Text = hotelDetail.Longitude.ToString();
            }
            ReadOnlyStateVisibility = Visibility.Visible;
            EditStateVisibility = Visibility.Collapsed;
        }

        private HotelService Service
        {
            get
            {
                return _service ?? (_service = new HotelService());
            }
        }



        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            if (btnSave.Content.Equals("Save"))
            {
                if (VerifyDetails())
                {
                    var hotel = new DTOHotel();
                    hotel.Id = Id;
                    hotel.IsNew = (Id <= 0);
                    hotel.HotelName = HotelName;
                    hotel.Description = Description;
                    hotel.Address = Address;
                    hotel.Phone = Phone;
                    hotel.Latitude = double.Parse(locationControl.txtLatitude.Text);
                    hotel.Longitude = double.Parse(locationControl.txtLongitude.Text);
                    _service.Save(hotel);
                    
                    btnSave.Content = "Edit";
                    ReadOnlyStateVisibility = Visibility.Visible;
                    EditStateVisibility = Visibility.Collapsed;
                }
            }

            else
            {
                btnSave.Content = "Save";
                ReadOnlyStateVisibility = Visibility.Collapsed;
                EditStateVisibility = Visibility.Visible;
            }
        }

        private bool VerifyDetails()
        {
            if(string.IsNullOrWhiteSpace(HotelName) 
                || string.IsNullOrWhiteSpace(Description)
                || string.IsNullOrWhiteSpace(Address)
                || string.IsNullOrWhiteSpace(Phone)
                || string.IsNullOrWhiteSpace(locationControl.txtLatitude.Text)
                || string.IsNullOrWhiteSpace(locationControl.txtLongitude.Text))
            {
                MessageBox.Show("All fields are mandatory.", "Missing data");
                return false;
            }
            return true;
        }

        private void BtnCancelClick(object sender, RoutedEventArgs e)
        {
            btnSave.Content = "Edit";
            ReadOnlyStateVisibility = Visibility.Visible;
            EditStateVisibility = Visibility.Collapsed;
        }
    }
}

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
using eConcierge.Business;
using eConcierge.CMSClient.Common;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsWindow
{
    /// <summary>
    /// Interaction logic for wndPointOfInterest.xaml
    /// </summary>
    public partial class wndPointOfInterest : WindowBase
    {
        private PointOfInterestService _service;
        private DTOPointOfInterest _poi;

        public wndPointOfInterest(PointOfInterestService service, DTOPointOfInterest poi, Action updateData)
        {
            _service = service;
            UpdateData = updateData;
            InitializeComponent();
            PopulateControl(poi);
        }

       

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            PopulateObject();
            if (_service.Save(_poi))
            {
                ShowCRUDSuccessMessage("Point of Interest saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private void PopulateObject()
        {
            _poi.Title = txtTitle.Text;
            _poi.Description = txtDescription.Text;
            _poi.Address = txtAddress.Text;
            _poi.Phone = txtPhone.Text;
            if(!string.IsNullOrWhiteSpace(photoUpload.FilePath))
            {
                _poi.Photo = ImageHelper.GetImage(photoUpload.FilePath);
            }
            if (!string.IsNullOrWhiteSpace(txtLatitude.Text))
            {
                _poi.Latitude = Convert.ToDouble(txtLatitude.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                _poi.Longitude = Convert.ToDouble(txtLongitude.Text);
            }

        }

        private void PopulateControl(DTOPointOfInterest poi)
        {
            _poi = poi;
            if (_poi != null)
            {
                txtTitle.Text = _poi.Title;
                txtDescription.Text = _poi.Description;
                txtAddress.Text = _poi.Address;
                txtPhone.Text = _poi.Phone;
                txtLatitude.Text = _poi.Latitude.ToString();
                txtLongitude.Text = _poi.Longitude.ToString();
                if(_poi.Photo != null)
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Visible;
                    photoUpload.ImageData = _poi.Photo;
                }
                else
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Collapsed;
                }
                _poi.IsNew = false;
            }
            else
            {
                _poi = new DTOPointOfInterest();
                _poi.IsNew = true;
            }
             
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
                txtTitle.Focus();
                return false;
            }

            if (!IsNumeric(txtLatitude.Text))
            {
                MessageBox.Show("Latitude can only be numeric value.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
                txtLatitude.Focus();
                return false;
            }

            if (!IsNumeric(txtLongitude.Text))
            {
                MessageBox.Show("Longitude can only be numeric value.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
                txtLongitude.Focus();
                return false;
            }
            
            return true;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
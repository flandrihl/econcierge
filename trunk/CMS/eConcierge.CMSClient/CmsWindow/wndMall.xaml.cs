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
    /// Interaction logic for wndMall.xaml
    /// </summary>
    public partial class wndMall : WindowBase
    {
        private MallService _service;
        private DTOMall _poi;

        public wndMall(MallService service, DTOMall poi, Action updateData)
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
                ShowCRUDSuccessMessage("Mall saved successfully.");
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
            if (!string.IsNullOrWhiteSpace(photoUpload.FilePath))
            {
                _poi.Photo = ImageHelper.GetImage(photoUpload.FilePath);
            }
            if (!string.IsNullOrWhiteSpace(latLong.txtLatitude.Text))
            {
                _poi.Latitude = Convert.ToDouble(latLong.txtLatitude.Text);
            }
            if (!string.IsNullOrWhiteSpace(latLong.txtLongitude.Text))
            {
                _poi.Longitude = Convert.ToDouble(latLong.txtLongitude.Text);
            }

        }

        private void PopulateControl(DTOMall poi)
        {
            _poi = poi;
            if (_poi != null)
            {
                txtTitle.Text = _poi.Title;
                txtDescription.Text = _poi.Description;
                txtAddress.Text = _poi.Address;
                txtPhone.Text = _poi.Phone;
                latLong.txtLatitude.Text = _poi.Latitude.ToString();
                latLong.txtLongitude.Text = _poi.Longitude.ToString();
                if (_poi.Photo != null)
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
                _poi = new DTOMall();
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

            if (!latLong.IsValid())
            {
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
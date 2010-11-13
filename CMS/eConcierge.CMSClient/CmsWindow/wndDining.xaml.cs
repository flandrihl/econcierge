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
    /// Interaction logic for wndDining.xaml
    /// </summary>
    public partial class wndDining : WindowBase
    {
        private DiningService _service;
        private DTODining _dining;

        public wndDining(DiningService service, DTODining dining, Action updateData)
        {
            _service = service;
            UpdateData = updateData;
            InitializeComponent();
            PopulateCategory();
            PopulateControl(dining);
        }

        private void PopulateCategory()
        {
            cmbSubCategory.SelectedValuePath = "Id";
            cmbSubCategory.DisplayMemberPath = "Title";
            cmbSubCategory.ItemsSource = new DiningSubCategoryService().GetDiningSubCategorys();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            PopulateObject();
            if (_service.Save(_dining))
            {
                ShowCRUDSuccessMessage("Dining saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private void PopulateObject()
        {
            _dining.Title = txtTitle.Text;
            _dining.Description = txtDescription.Text;
            if (cmbSubCategory.SelectedIndex >= 0)
            {
                _dining.SubCategoryId = Convert.ToInt32(cmbSubCategory.SelectedValue);
            }
            _dining.Address = txtLocation.Text;
            _dining.Telephone = txtPhone.Text;
            if(!string.IsNullOrWhiteSpace(photoUpload.FilePath))
            {
                _dining.Photo = ImageHelper.GetImage(photoUpload.FilePath);
            }
            if (!string.IsNullOrWhiteSpace(txtLatitude.Text))
            {
                _dining.Latitude = Convert.ToDouble(txtLatitude.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                _dining.Longitude = Convert.ToDouble(txtLongitude.Text);
            }

        }

        private void PopulateControl(DTODining dining)
        {
            _dining = dining;
            if (_dining != null)
            {
                txtTitle.Text = _dining.Title;
                txtDescription.Text = _dining.Description;
                if (_dining.SubCategoryId > 0)
                {
                    cmbSubCategory.SelectedValue = _dining.SubCategoryId;
                }
               
                txtLocation.Text = _dining.Address;
                txtPhone.Text = _dining.Telephone;
                txtLatitude.Text = _dining.Latitude.ToString();
                txtLongitude.Text = _dining.Longitude.ToString();
                if(_dining.Photo != null)
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Visible;
                    photoUpload.ImageData = _dining.Photo;
                }
                else
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Collapsed;
                }
                _dining.IsNew = false;
            }
            else
            {
                _dining = new DTODining();
                _dining.IsNew = true;
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

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
    /// Interaction logic for wndCalendarEvent.xaml
    /// </summary>
    public partial class wndCalendarEvent : WindowBase
    {
        private CalendarEventService _service;
        private DTOCalendarEvent _evnt;

        public wndCalendarEvent(CalendarEventService service, DTOCalendarEvent evnt, Action updateData)
        {
            _service = service;
            UpdateData = updateData;
            InitializeComponent();
            PopulateCategory();
            PopulateControl(evnt);
        }

        private void PopulateCategory()
        {
            cmbCategory.SelectedValuePath = "Id";
            cmbCategory.DisplayMemberPath = "Name";
            cmbCategory.ItemsSource = new EventCalendarCategoryService().GetEventCalendarCategorys();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            PopulateObject();
            if (_service.Save(_evnt))
            {
                ShowCRUDSuccessMessage("Event saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private void PopulateObject()
        {
            _evnt.Title = txtTitle.Text;
            _evnt.Description = txtDescription.Text;
            if (cmbCategory.SelectedIndex > 0)
            {
                _evnt.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            }
            _evnt.StartDate = dtpStartDate.SelectedDate;
            _evnt.EndDate = dtpEndDate.SelectedDate;
            _evnt.Location = txtLocation.Text;
            if(!string.IsNullOrWhiteSpace(photoUpload.FilePath))
            {
                _evnt.Photo = ImageHelper.GetImage(photoUpload.FilePath);
            }
            if (!string.IsNullOrWhiteSpace(txtLatitude.Text))
            {
                _evnt.Latitude = Convert.ToDouble(txtLatitude.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtLongitude.Text))
            {
                _evnt.Longitude = Convert.ToDouble(txtLongitude.Text);
            }

        }

        private void PopulateControl(DTOCalendarEvent evnt)
        {
            _evnt = evnt;
            if (_evnt != null)
            {
                txtTitle.Text = _evnt.Title;
                txtDescription.Text = _evnt.Description;
                if (_evnt.CategoryId > 0)
                {
                    cmbCategory.SelectedValue = _evnt.CategoryId;
                }
                dtpStartDate.SelectedDate = _evnt.StartDate;
                dtpEndDate.SelectedDate = _evnt.EndDate;
                txtLocation.Text = _evnt.Location;
                txtLatitude.Text = _evnt.Latitude.ToString();
                txtLongitude.Text = _evnt.Longitude.ToString();
                if(_evnt.Photo != null)
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Visible;
                    photoUpload.ImageData = _evnt.Photo;
                }
                else
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Collapsed;
                }
                _evnt.IsNew = false;
            }
            else
            {
                _evnt = new DTOCalendarEvent();
                _evnt.IsNew = true;
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

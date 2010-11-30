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
    /// Interaction logic for wndTransportationTaxi.xaml
    /// </summary>
    public partial class wndTransportationTaxi : WindowBase
    {
        private TransportationTaxiService _service;
        private DTOTransportationTaxi _poi;

        public wndTransportationTaxi(TransportationTaxiService service, DTOTransportationTaxi poi, Action updateData)
        {
            _service = service;
            UpdateData = updateData;
            InitializeComponent();
            PopulateTransportationType();
            PopulateControl(poi);
        }

        private void PopulateTransportationType()
        {
            cmbCategory.SelectedValuePath = "Id";
            cmbCategory.DisplayMemberPath = "Title";
            cmbCategory.ItemsSource = new TransportationService().GetTransportations(TransportationType.Taxi);
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            PopulateObject();
            if (_service.Save(_poi))
            {
                ShowCRUDSuccessMessage("Taxi saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private void PopulateObject()
        {
            _poi.Title = txtTitle.Text;
            _poi.TranspotationId = Convert.ToInt32(cmbCategory.SelectedValue);
            _poi.Phone = txtPhone.Text;
        }

        private void PopulateControl(DTOTransportationTaxi poi)
        {
            _poi = poi;
            if (_poi != null)
            {
                txtTitle.Text = _poi.Title;
                cmbCategory.SelectedValue = _poi.TranspotationId;
                txtPhone.Text = _poi.Phone;
                _poi.IsNew = false;
            }
            else
            {
                _poi = new DTOTransportationTaxi();
                _poi.IsNew = true;
            }

        }

        //public bool IsValid()
        //{
        //    if (string.IsNullOrWhiteSpace(txtTitle.Text))
        //    {
        //        MessageBox.Show("Title cannot be empty.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
        //        txtTitle.Focus();
        //        return false;
        //    }

        //    if (cmbCategory.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Select a category.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
        //        cmbCategory.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtPhone.Text))
        //    {
        //        MessageBox.Show("Phone Number cannot be empty.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
        //        txtPhone.Focus();
        //        return false;
        //    }

        //    return true;
        //}


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
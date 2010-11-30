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
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsWindow
{
    /// <summary>
    /// Interaction logic for wndTransportation.xaml
    /// </summary>
    public partial class wndTransportation : WindowBase
    {
        private TransportationService _service;
        private DTOTransportation _category;

        public wndTransportation(TransportationService service, DTOTransportation category, Action updateData)
        {
            _service = service;
            UpdateData = updateData;
            InitializeComponent();
            PopulateControl(category);
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            PopulateObject();
            if (_service.Save(_category))
            {
                ShowCRUDSuccessMessage("Category saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private void PopulateObject()
        {
            _category.Title = txtTitle.Text;
            _category.Description = txtDescription.Text;
            if(rdoMonorail.IsChecked.Value)
            {
                _category.TransportationType = 1;
            }
            else
            {
                _category.TransportationType = 2;
            }

        }

        private void PopulateControl(DTOTransportation category)
        {
            _category = category;
            if (_category != null)
            {
                txtTitle.Text = _category.Title;
                txtDescription.Text = _category.Description;
                _category.IsNew = false;
                if(_category.TransportationType == 2)
                {
                    rdoTaxi.IsChecked = true;
                }
                if(HasChild())
                {
                    rdoMonorail.Visibility = rdoTaxi.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                _category = new DTOTransportation();
                _category.IsNew = true;
            }
        }

        private bool HasChild()
        {
            if (new TransportationTaxiService().GetTransportationTaxisByTransporation(_category.Id).Count > 0)
                return true;
            if (new TransportationMonorailService().GetTransportationMonorailsByTransportation(_category.Id).Count > 0)
                return true;
            return false;
        }

        //public bool IsValid()
        //{
        //    if (string.IsNullOrWhiteSpace(txtTitle.Text))
        //    {
        //        MessageBox.Show("Title cannot be empty.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
        //        txtTitle.Focus();
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

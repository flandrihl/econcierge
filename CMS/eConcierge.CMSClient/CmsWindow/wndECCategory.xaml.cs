﻿using System;
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
    /// Interaction logic for wndECCategory.xaml
    /// </summary>
    public partial class wndECCategory : WindowBase
    {
        private EventCalendarCategoryService _service;
        private DTOEventCalendarCategory _category;

        public wndECCategory(EventCalendarCategoryService service, DTOEventCalendarCategory category, Action updateData)
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
            _category.Name = txtName.Text;
            _category.Description = txtDescription.Text;

        }

        private void PopulateControl(DTOEventCalendarCategory category)
        {
            _category = category;
            if (_category != null)
            {
                txtName.Text = _category.Name;
                txtDescription.Text = _category.Description;
                _category.IsNew = false;
            }
            else
            {
                _category = new DTOEventCalendarCategory();
                _category.IsNew = true;
            }
        }

        //public bool IsValid()
        //{
        //    if (string.IsNullOrWhiteSpace(txtName.Text))
        //    {
        //        MessageBox.Show("Name cannot be empty.", WellKnownNames.MessageString.IncorrectInput, MessageBoxButton.OK, MessageBoxImage.Error);
        //        txtName.Focus();
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

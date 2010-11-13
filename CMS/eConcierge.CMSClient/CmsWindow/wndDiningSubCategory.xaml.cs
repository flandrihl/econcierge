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
    /// Interaction logic for wndDiningSubCategory.xaml
    /// </summary>
    public partial class wndDiningSubCategory : WindowBase
    {
         private DiningSubCategoryService _service;
        private DTODiningSubCategory _category;

        public wndDiningSubCategory(DiningSubCategoryService service, DTODiningSubCategory category, Action updateData)
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

        }

        private void PopulateControl(DTODiningSubCategory category)
        {
            _category = category;
            if (_category != null)
            {
                txtTitle.Text = _category.Title;
                txtDescription.Text = _category.Description;
                _category.IsNew = false;
            }
            else
            {
                _category = new DTODiningSubCategory();
                _category.IsNew = true;
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
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

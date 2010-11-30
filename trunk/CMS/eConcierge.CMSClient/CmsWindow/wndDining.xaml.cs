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
using eConcierge.CMSClient.CmsUserControl;
using eConcierge.CMSClient.Common;
using eConcierge.Common;
using eConcierge.Model;
using Microsoft.Win32;

namespace eConcierge.CMSClient.CmsWindow
{
    /// <summary>
    /// Interaction logic for wndDining.xaml
    /// </summary>
    public partial class wndDining : WindowBase
    {
        private DiningService _service;
        private DTODining _dining;
        private List<string> _menuList = new List<string>();

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
            List<DTODiningMenu> menuList = GetMenuList();
            if (_service.Save(_dining, menuList))
            {
                ShowCRUDSuccessMessage("Dining saved successfully.");
            }
            else
            {
                ShowCRUDErrorMessage();
            }
        }

        private List<DTODiningMenu> GetMenuList()
        {
            List<DTODiningMenu> list = new List<DTODiningMenu>();
            foreach (string path in _menuList)
            {
                if (path.Contains('\\'))
                {
                    DTODiningMenu menu = new DTODiningMenu();
                    menu.Photo = ImageHelper.GetImage(path);
                    menu.FileName = GetFileName(path);
                    if (!_dining.IsNew)
                    {
                        menu.DiningId = _dining.Id;
                    }
                    list.Add(menu);
                }
            }
            return list;
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
            if (!string.IsNullOrWhiteSpace(photoUpload.FilePath))
            {
                _dining.Photo = ImageHelper.GetImage(photoUpload.FilePath);
            }

            _dining.Latitude = latLong.Latitude;
            _dining.Longitude = latLong.Longitude;


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
                latLong.txtLatitude.Text = _dining.Latitude.ToString();
                latLong.txtLongitude.Text = _dining.Longitude.ToString();
                if (_dining.Photo != null)
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Visible;
                    photoUpload.ImageData = _dining.Photo;
                }
                else
                {
                    photoUpload.IsSeeVisible = System.Windows.Visibility.Collapsed;
                }
                _dining.IsNew = false;
                List<DTODiningMenu> menuList = new DiningMenuService().GetDiningMenusByDining(_dining.Id);
                foreach (var menu in menuList)
                {
                    AddMenuToStackPanel(menu.FileName, menu.Id);
                }
            }
            else
            {
                _dining = new DTODining();
                _dining.IsNew = true;
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

        //    if (!latLong.IsValid())
        //    {
        //        return false;
        //    }

        //    return true;
        //}


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG files|*.jpg|png files|*.png";
            if (dialog.ShowDialog().Value)
            {
                string fileName = dialog.FileName;
                _menuList.Add(fileName);
                AddMenuToStackPanel(fileName);
            }
        }

        private void AddMenuToStackPanel(string fileName, int menuId = -1)
        {
            DiningMenuPhotoItem item = new DiningMenuPhotoItem();
            item.RemovedMenuItem += new EventHandler(item_RemovedMenuItem);
            item.PhotoPath = fileName;
            item.Tag = menuId;
            stkMenu.Children.Add(item);
        }

        void item_RemovedMenuItem(object sender, EventArgs e)
        {
            DiningMenuPhotoItem item = (DiningMenuPhotoItem)sender;
            int id = Convert.ToInt32(item.Tag);
            if (id > 0)
            {
                if (MessageBox.Show("Are you sure, you want to remove this item from database?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    new DiningMenuService().Delete(id);
                }
                else
                {
                    return;
                }
            }
            _menuList.Remove(item.PhotoPath);
            stkMenu.Children.Remove(item);
        }
    }
}

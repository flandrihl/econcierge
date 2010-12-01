using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using eConcierge.CMSClient.CmsUserControl;
using eConcierge.CMSClient.Common;

namespace eConcierge.CMSClient.CmsWindow
{
    public abstract class WindowBase:Window
    {
        public Action UpdateData;
        public WindowBase()
        {
            ShowInTaskbar = false;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowStyle = WindowStyle.ToolWindow;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = System.Windows.ResizeMode.NoResize;
            this.SetResourceReference(Window.BackgroundProperty, "ButtonNormalBackground");
          
        }

        protected void ShowCRUDErrorMessage()
        {
            MessageBox.Show("An error occured while executing your request.", "Failed", MessageBoxButton.OK,
                              MessageBoxImage.Error);
        }


        protected void ShowCRUDSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButton.OK,
                            MessageBoxImage.Information);
            UpdateData();
            this.Close();
        }
        protected bool IsNumeric(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return true;
            }
            Double result;
            return Double.TryParse(value, out result);

        }

        protected string GetFileName(string fileName)
        {
            if (fileName.LastIndexOf('\\') > -1)
            {
                return fileName.Substring(fileName.LastIndexOf('\\') + 1, fileName.Length - fileName.LastIndexOf('\\') - 1);
            }
            else
            {
                return fileName;
            }
        }
        protected virtual bool IsValid()
        {
            return IsValid(this);
        }
        private bool IsValid(Visual control)
        {
            var textBoxs = control.FindChildren<TextBox>();
            var combos = control.FindChildren<ComboBox>();
            var latLon = control.FindChildren<LatitudeLongitude>();
            foreach (var textBox in textBoxs)
            {
                if(string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("All text fields are mandatory.", "Enter data", MessageBoxButton.OK,MessageBoxImage.Information);
                    return false;
                }
            }

            foreach (var comboBox in combos)
            {
                if (comboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a value from dropdown", "Select data", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }

            foreach (var latitudeLongitude in latLon)
            {
                if (string.IsNullOrWhiteSpace(latitudeLongitude.txtLatitude.Text) || string.IsNullOrWhiteSpace(latitudeLongitude.txtLongitude.Text))
                {
                    MessageBox.Show("Please select a location", "Select location", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            //int ChildNumber = VisualTreeHelper.GetChildrenCount(control);

            //for (int i = 0; i <= ChildNumber - 1; i++)
            //{
            //    Visual v = (Visual)VisualTreeHelper.GetChild(control, i);
            //    if(v is TextBox)
            //    {
            //        TextBox txt = (TextBox)v;
            //        if(string.IsNullOrWhiteSpace(txt.Text))
            //        {
            //            MessageBox.Show("All fields are mandatory.", "Enter data", MessageBoxButton.OK,
            //                            MessageBoxImage.Information);
            //            txt.Focus();
            //            return false;
            //        }
            //    }
            //    if (VisualTreeHelper.GetChildrenCount(v) > 0)
            //    {
            //       bool isValid = IsValid(v);
            //        if(!isValid)
            //        {
            //            return false;
            //        }
            //    }
            //}
            return true;

        }
       
    }
}

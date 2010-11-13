using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

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
    }
}

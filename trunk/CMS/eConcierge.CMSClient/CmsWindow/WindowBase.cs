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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            WindowStyle = System.Windows.WindowStyle.ToolWindow;
          
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
    }
}

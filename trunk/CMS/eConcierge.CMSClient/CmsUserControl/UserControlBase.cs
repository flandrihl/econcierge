using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace eConcierge.CMSClient.CmsUserControl
{
    public class UserControlBase:UserControl
    {
        protected void ShowCRUDErrorMessage()
        {
            MessageBox.Show("An error occured while executing your request.", "Failed", MessageBoxButton.OK,
                              MessageBoxImage.Error);
        }

        protected void ShowDeleteSuccessMessage()
        {
            MessageBox.Show("Item has been deleted successfully.", "Success", MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}

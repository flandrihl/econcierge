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
using System.Windows.Navigation;
using System.Windows.Shapes;
using eConcierge.Business;
using eConcierge.CMSClient.CmsWindow;
using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for MallDetail.xaml
    /// </summary>
    public partial class MallDetail : UserControlBase
    {
        private MallService _service;
        public MallDetail()
        {
            InitializeComponent();
            PrepareView();
        }

        private void PrepareView()
        {
            grd.ItemsSource = Service.GetMalls();
        }

        private MallService Service
        {
            get
            {
                return _service ?? (_service = new MallService());
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOMall item = (DTOMall)grd.SelectedItem;
            Save(item);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show(WellKnownNames.MessageString.DeleteConfirmationMessage, WellKnownNames.MessageString.Confirmation, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Image img = (Image)sender;
                if (Service.Delete(Convert.ToInt32(img.Tag)))
                {
                    ShowDeleteSuccessMessage();
                    PrepareView();
                }
                else
                {
                    ShowCRUDErrorMessage();
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void Save(DTOMall item = null)
        {
            wndMall wnd = new wndMall(Service, item, PrepareView);
            wnd.ShowDialog();
        }
    }
}

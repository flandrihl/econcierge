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
    /// Interaction logic for TransportationTaxiDetail.xaml
    /// </summary>
    public partial class TransportationTaxiDetail : UserControlBase
    {
        private TransportationTaxiService _service;
        public TransportationTaxiDetail()
        {
            InitializeComponent();
            PrepareView();
        }

        private void PrepareView()
        {
            grd.ItemsSource = Service.GetTransportationTaxis();
        }

        private TransportationTaxiService Service
        {
            get
            {
                return _service ?? (_service = new TransportationTaxiService());
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOTransportationTaxi item = (DTOTransportationTaxi)grd.SelectedItem;
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
        private void Save(DTOTransportationTaxi item = null)
        {
            wndTransportationTaxi wnd = new wndTransportationTaxi(Service, item, PrepareView);
            wnd.ShowDialog();
        }
    }
}

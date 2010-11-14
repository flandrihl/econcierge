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
    /// Interaction logic for PointOfInterestDetail.xaml
    /// </summary>
    public partial class PointOfInterestDetail : UserControlBase
    {
        private PointOfInterestService _service;
        public PointOfInterestDetail()
        {
            InitializeComponent();
            PrepareView();
        }

        private void PrepareView()
        {
            grd.ItemsSource = Service.GetPointOfInterests();
        }

        private PointOfInterestService Service
        {
            get
            {
                return _service ?? (_service = new PointOfInterestService());
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOPointOfInterest item = (DTOPointOfInterest)grd.SelectedItem;
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
        private void Save(DTOPointOfInterest item = null)
        {
            wndPointOfInterest wnd = new wndPointOfInterest(Service, item, PrepareView);
            wnd.ShowDialog();
        }
    }
}

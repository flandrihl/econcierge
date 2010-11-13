using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using eConcierge.CMSClient.CmsWindow;
using eConcierge.Common;
using eConcierge.Business;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for EventCalendarCategoryDetail.xaml
    /// </summary>

    public partial class EventCalendarCategoryDetail : UserControlBase
    {
        private EventCalendarCategoryService _service;
        public EventCalendarCategoryDetail()
        {
            InitializeComponent();
            PrepareView();
        }

        private void PrepareView()
        {
            grd.ItemsSource = Service.GetEventCalendarCategorys();
        }

        private EventCalendarCategoryService Service
        {
            get
            {
                return _service ?? (_service = new EventCalendarCategoryService());
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOEventCalendarCategory category = (DTOEventCalendarCategory)grd.SelectedItem;
            Save(category);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show(WellKnownNames.MessageString.DeleteConfirmationMessage, WellKnownNames.MessageString.Confirmation, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Image img = (Image)sender;
               if(Service.Delete(Convert.ToInt32(img.Tag)))
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
        private void Save(DTOEventCalendarCategory category=null)
        {
            wndECCategory wnd = new wndECCategory(Service, category, PrepareView);
            wnd.ShowDialog();
        }

    }
}

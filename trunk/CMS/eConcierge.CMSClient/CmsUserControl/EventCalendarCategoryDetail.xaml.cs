using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
//using eConcierge.Common;
using eConcierge.Model;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for EventCalendarCategoryDetail.xaml
    /// </summary>
     
    public partial class EventCalendarCategoryDetail : UserControl
    {
        public EventCalendarCategoryDetail()
        {
            InitializeComponent();
        }
        

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOEventCalendarCategory v = (DTOEventCalendarCategory)grd.SelectedItem;
           // ((EventCalendarCategoryPresenter) DataContext).Edit(v);
            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // if (MessageBox.Show(WellKnownNames.MessageString.DeleteConfirmationMessage, WellKnownNames.MessageString.Confirmation, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Image img = (Image)sender;
               // ((EventCalendarCategoryPresenter)DataContext).Delete(Convert.ToInt32(img.Tag));
            }
        }
    }
}

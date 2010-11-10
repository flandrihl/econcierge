using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
using eConcierge.Common;
using eConcierge.Foundation.Presenters;
using eConcierge.Model;
using eConcierge.Resort.Applications.Presenters;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Presentation.EventCalendar
{
    /// <summary>
    /// Interaction logic for CalendarEventToolView.xaml
    /// </summary>
   [Export(typeof(ICalendarEventToolView))]
    public partial class CalendarEventToolView : ICalendarEventToolView
    {
        public CalendarEventToolView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOCalendarEvent v = (DTOCalendarEvent)grd.SelectedItem;
            ((CalendarEventPresenter)DataContext).Edit(v);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show(WellKnownNames.MessageString.DeleteConfirmationMessage, WellKnownNames.MessageString.Confirmation, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Image img = (Image)sender;
                ((CalendarEventPresenter)DataContext).Delete(Convert.ToInt32(img.Tag));
            }
        }
    }
}

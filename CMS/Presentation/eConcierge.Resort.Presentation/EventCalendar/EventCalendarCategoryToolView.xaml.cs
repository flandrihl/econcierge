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
using eConcierge.Foundation.Presenters;
using eConcierge.Model;
using eConcierge.Resort.Applications.Presenters;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Presentation
{
    /// <summary>
    /// Interaction logic for EventCalendarCategoryToolView.xaml
    /// </summary>
     [Export(typeof(IEventCalendarCategoryToolView))]
    public partial class EventCalendarCategoryToolView : IEventCalendarCategoryToolView
    {
        public EventCalendarCategoryToolView()
        {
            InitializeComponent();
        }
        public IPresenter Presenter
        {
            set { DataContext = value; }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DTOEventCalendarCategory v = (DTOEventCalendarCategory)grd.SelectedItem;
            ((EventCalendarCategoryPresenter) DataContext).Edit(v);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Are you sure, you want to delete this item.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Image img = (Image)sender;
                ((EventCalendarCategoryPresenter)DataContext).Delete(Convert.ToInt32(img.Tag));
            }
        }
    }
}

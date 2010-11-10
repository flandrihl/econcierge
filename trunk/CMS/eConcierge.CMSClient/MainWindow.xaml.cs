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
using eConcierge.CMSClient.CmsUserControl;

namespace eConcierge.CMSClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateMenu();
        }

        private void PopulateMenu()
        {
            mnu.AddMainMenu("EventCalendar", "Event Calendar", true);
            mnu.AddsubMenu("EventCalendar", "Category", "Category", ShowItem, true);
            mnu.AddsubMenu("EventCalendar", "Event", "Event", ShowItem);

            mnu.AddMainMenu("Dingin", "Dingin", true);
            mnu.AddsubMenu("Dingin", "Category1", "Category1", ShowItem, true);
            mnu.AddsubMenu("Dingin", "Event1", "Event1", ShowItem);
        }
       
        private void ShowItem(string name)
        {
            if (name.Equals("Category"))
            {
                EventCalendarCategoryDetail detail = new EventCalendarCategoryDetail();
                middleRegion.Content = detail;
            }
        }
    }
}

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
using eConcierge.Common;

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
            mnu.AddMainMenu(WellKnownNames.ToolbarString.EventCalendar, "Event Calendar", true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.EventCalendar, WellKnownNames.ToolbarString.ECCategory, "Category", ShowItem, true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.EventCalendar, WellKnownNames.ToolbarString.ECEvent, "Event", ShowItem);

            mnu.AddMainMenu(WellKnownNames.ToolbarString.Dining, "Dining");
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Dining, "Category", "Category", ShowItem, true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Dining, "Event1", "Event1", ShowItem);
        }
       
        private void ShowItem(string name)
        {
            if (name.Equals(WellKnownNames.ToolbarString.ECCategory))
            {
                SetMiddleContent<EventCalendarCategoryDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.ECEvent))
            {
                SetMiddleContent<CalendarEventDetail>();
            }
            
        }
        private void SetMiddleContent<T>() where T:class, new() 
        {
            T detail = new T();
            middleRegion.Content = detail;
        }
    }
}

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
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Dining, WellKnownNames.ToolbarString.DiningCategory, "Category", ShowItem, true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Dining, WellKnownNames.ToolbarString.DiningSubCategory, "Sub Category", ShowItem);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Dining, WellKnownNames.ToolbarString.DiningDetail, "Dining Detail", ShowItem);

            mnu.AddMainMenu(WellKnownNames.ToolbarString.Facility, "Facility");
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Facility, WellKnownNames.ToolbarString.PointOfInterest, "Point Of Interest", ShowItem, true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Facility, WellKnownNames.ToolbarString.ATM, "ATM", ShowItem);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Facility, WellKnownNames.ToolbarString.Cafe, "Cafe", ShowItem);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Facility, WellKnownNames.ToolbarString.Mall, "Mall", ShowItem);

            mnu.AddMainMenu(WellKnownNames.ToolbarString.Transportation, "Transportation");
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Transportation, WellKnownNames.ToolbarString.TransportationCategory, "Category", ShowItem, true);
            mnu.AddsubMenu(WellKnownNames.ToolbarString.Transportation, WellKnownNames.ToolbarString.TransportationDetail, "Detail", ShowItem);
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
            else if (name.Equals(WellKnownNames.ToolbarString.DiningCategory))
            {
                SetMiddleContent<DiningCategoryDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.DiningSubCategory))
            {
                SetMiddleContent<DiningSubCategoryDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.DiningDetail))
            {
                SetMiddleContent<DiningDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.PointOfInterest))
            {
                SetMiddleContent<PointOfInterestDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.ATM))
            {
                SetMiddleContent<ATMDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.Cafe))
            {
                SetMiddleContent<CafeDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.Mall))
            {
                SetMiddleContent<MallDetail>();
            }
            else if (name.Equals(WellKnownNames.ToolbarString.TransportationCategory))
            {
                SetMiddleContent<TransportationDetail>();
            }
            
        }
        private void SetMiddleContent<T>() where T:class, new() 
        {
            T detail = new T();
            middleRegion.Content = detail;
        }
    }
}

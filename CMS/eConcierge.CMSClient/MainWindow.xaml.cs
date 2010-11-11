﻿using System;
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

            mnu.AddMainMenu("Dingin", "Dingin", true);
            mnu.AddsubMenu("Dingin", "Category1", "Category1", ShowItem, true);
            mnu.AddsubMenu("Dingin", "Event1", "Event1", ShowItem);
        }
       
        private void ShowItem(string name)
        {
            if (name.Equals(WellKnownNames.ToolbarString.ECCategory))
            {
                EventCalendarCategoryDetail detail = new EventCalendarCategoryDetail();
                middleRegion.Content = detail;
            }
            
        }
    }
}

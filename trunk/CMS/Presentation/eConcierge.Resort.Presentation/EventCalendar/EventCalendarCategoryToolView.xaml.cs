﻿using System;
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
            var v = grd.SelectedItem;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using eConcierge.Business;

namespace eConcierge.CMSClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if(!new WarmUpService().CanConnectToDatabase())
            {
                MessageBox.Show(
                    "Cannot connect to database. Please check the connection string and make sure database server is running.",
                    "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

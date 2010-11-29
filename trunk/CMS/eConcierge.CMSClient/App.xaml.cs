using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using eConcierge.Business;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

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
            if (!new WarmUpService().CanConnectToDatabase())
            {
                MessageBox.Show(
                    "Cannot connect to database. Please check the connection string and make sure database server is running.",
                    "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            #if (!DEBUG)
            {	
                ConfigureDatabase();
            }
            #endif
          
        }
        private void ConfigureDatabase()
        {
            string targetDirectory = Assembly.GetExecutingAssembly().Location;
            if (targetDirectory != null)
                targetDirectory = targetDirectory.Substring(0, targetDirectory.LastIndexOf('\\'));

            string path = Path.Combine(targetDirectory, "script.sql");
            if (!File.Exists(path))
                return;
            string sql = string.Empty;
            sql = File.ReadAllText(path);
            string connStr = ConfigurationManager.ConnectionStrings["eConciergeDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.Connect();
                    if (server.ConnectionContext.IsOpen)
                        server.ConnectionContext.Disconnect();
                    server.ConnectionContext.ExecuteNonQuery(sql);
                    File.Delete(path);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}

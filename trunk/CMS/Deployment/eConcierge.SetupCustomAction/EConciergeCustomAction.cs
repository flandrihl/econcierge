using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace eConcierge.SetupCustomAction
{
    [RunInstaller(true)]
    public partial class EConciergeCustomAction : Installer
    {
        public EConciergeCustomAction()
        {
            InitializeComponent();
        }
        private string logFilePath = "C:\\SetupLog.txt";
       

        private string GetSql(string Name)
        {
            try
            {

                // Gets the current assembly.
                Assembly Asm = Assembly.GetExecutingAssembly();

                // Resources are named using a fully qualified name.
                Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

                // Reads the contents of the embedded file.
                StreamReader reader = new StreamReader(strm);

                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                throw ex;
            }
        }
        private void ExecuteSql(string serverName, string dbName, string userName, string password, string Sql)
        {
            string connStr = string.Format("Data Source={0};Initial Catalog={1}; User Id={2};Password={3}", serverName, dbName, userName, password);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    Server server = new Server(new ServerConnection(conn));
                    server.ConnectionContext.ExecuteNonQuery(Sql);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            }
        }
        public void CreateDatabase(string serverName, string databaseName, string userName, string password)
        {
            try
            {
                // Creates the database and installs the tables.
                string strScript = GetSql("script.sql");
                Server myServer = new Server(serverName);
                myServer.ConnectionContext.LoginSecure = false;
                myServer.ConnectionContext.Login = userName;
                myServer.ConnectionContext.Password = password;
                Database myDatabase = new Database(myServer, databaseName);
                myDatabase.Create();

                if (myServer.ConnectionContext.IsOpen)
                    myServer.ConnectionContext.Disconnect();
                ExecuteSql(serverName, databaseName, userName, password, strScript);
            }
            catch (Exception ex)
            {
                //Reports any errors and abort.
                Log(ex.ToString());
                throw ex;
            }
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            
            base.Install(stateSaver);
            try
            {
                Log("Setup started");
                

                string targetDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                if (targetDirectory != null)
                    targetDirectory = targetDirectory.Substring(0, targetDirectory.LastIndexOf('\\'));

                var param1 = Context.Parameters["sname"];
                var param2 = Context.Parameters["dname"];
                var param3 = Context.Parameters["uname"];
                var param4 = Context.Parameters["password"];

                CreateDatabase(param1, param2, param3, param4);

                var exePath = string.Format("{0}\\eConcierge.CMSClient.exe", targetDirectory);
                var config = ConfigurationManager.OpenExeConfiguration(exePath);

                config.ConnectionStrings.ConnectionStrings["eConciergeDB"].ConnectionString = string.Format("Data Source={0};Initial Catalog={1}; User Id={2};Password={3}", param1, param2, param3, param4);
                config.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Log(string str)
        {
            StreamWriter Tex;
            try
            {
                Tex = File.AppendText(this.logFilePath);
                Tex.WriteLine(DateTime.Now.ToString() + " " + str);
                Tex.Close();
            }
            catch
            { }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;


namespace SetupCustomAction
{
    [RunInstaller(true)]
    public partial class EConciergeClientCustomAction : System.Configuration.Install.Installer
    {
        public EConciergeClientCustomAction()
        {
            InitializeComponent();
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {

            base.Install(stateSaver);
            try
            {
                string targetDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                if (targetDirectory != null)
                    targetDirectory = targetDirectory.Substring(0, targetDirectory.LastIndexOf('\\'));

                var param1 = Context.Parameters["sname"];
                var param2 = Context.Parameters["dname"];
                var param3 = Context.Parameters["uname"];
                var param4 = Context.Parameters["password"];

                var exePath = string.Format("{0}\\eConciergeClient.exe", targetDirectory);
                var config = ConfigurationManager.OpenExeConfiguration(exePath);

                config.ConnectionStrings.ConnectionStrings["eConciergeDB"].ConnectionString = string.Format("Data Source={0};Initial Catalog={1}; User Id={2};Password={3}", param1, param2, param3, param4);
                config.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using eConcierge.Domain;
using Microsoft.Practices.Composite.MefExtensions;

namespace eConcierge.Shell
{
    public class eConciergeBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Container.ComposeExportedValue(new ShellPresenter(new ShellView()));
            return (DependencyObject) Container.GetExportedValue<ShellPresenter>().View;
        }

        public ShellPresenter GetShell()
        {
            return Container.GetExportedValue<ShellPresenter>();
        }
        
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(eConciergeBootstrapper).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(eConciergeEntities).Assembly));
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog("Modules"));
        }
    }
}

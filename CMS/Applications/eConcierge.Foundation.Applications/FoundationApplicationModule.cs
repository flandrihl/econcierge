using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Constants;
using Microsoft.Practices.Composite.MefExtensions.Modularity;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;

namespace eConcierge.Foundation.Applications
{
    [ModuleExport(typeof(FoundationApplicationModule))]
    public class FoundationApplicationModule:IModule
    {
        [Import]
        private IRegionManager RegionManager { get; set; }
        [Import]
        private HeaderPresenter HeaderPresenter { get; set; }
        public void Initialize()
        {
            RegionManager.Regions[RegionNames.TopRegion].Add(HeaderPresenter.View);
        }
    }
}

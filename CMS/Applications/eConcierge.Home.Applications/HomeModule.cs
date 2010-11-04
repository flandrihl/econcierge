using System;
using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.ToolManagement;
using eConcierge.Foundation.Constants;
using eConcierge.Home.Applications.Presenters;
using Microsoft.Practices.Composite.MefExtensions.Modularity;
using Microsoft.Practices.Composite.Modularity;

namespace eConcierge.Home.Applications
{
    [ModuleExport(typeof(HomeModule), DependsOnModuleNames = new[] { "FoundationApplicationModule" })]
    public class HomeModule:IModule
    {
        [Import]
        private Lazy<ToolManager> ToolManager { get; set; }
        [Import]
        private Lazy<HomeToolPresenter> HomeToolPresenter { get; set; }
        [Import]
        private Lazy<IFooterPresenter> FooterPresenter { get; set; }

        public void Initialize()
        {
            ToolManager.Value.CreateMainMenu(ToolNames.Home, StringTable.HomeMenuHeader,true);
            ToolManager.Value.AddActiveView(ToolNames.Home, RegionNames.MiddleRegion, HomeToolPresenter);
            ToolManager.Value.AddActiveView(ToolNames.Home, RegionNames.BottomRegion, FooterPresenter);
            ToolManager.Value.Activate(ToolNames.Home);
            
        }
    }
}

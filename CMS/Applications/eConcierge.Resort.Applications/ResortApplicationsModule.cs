using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.ToolManagement;
using eConcierge.Foundation.Constants;
using eConcierge.Resort.Applications.Presenters;
using Microsoft.Practices.Composite.MefExtensions.Modularity;
using Microsoft.Practices.Composite.Modularity;

namespace eConcierge.Resort.Applications
{
    [ModuleExport(typeof(ResortApplicationsModule), DependsOnModuleNames = new[] { "HomeModule" })]
    public class ResortApplicationsModule : IModule
    {
        [Import]
        private Lazy<ToolManager> ToolManager { get; set; }

        [Import]
        private Lazy<VideoToolPresenter> VideoToolPresenter { get; set; }

        [Import]
        private Lazy<EventCalendarCategoryPresenter> EventCalendarCategoryToolPresenter { get; set; }

        [Import]
        private Lazy<IFooterPresenter> FooterPresenter { get; set; }
        //[Import]
        //private Lazy<DepositToolPresenter> DepositToolPresenter { get; set; }

        public void Initialize()
        {
            ToolManager.Value.CreateMainMenu(ToolNames.Resort, StringTable.ResortMenuHeader);
            ToolManager.Value.CreateSubMenu(ToolNames.Resort, ToolNames.Video, StringTable.VideoMenuHeader, true);
           
            ToolManager.Value.CreateMainMenu(ToolNames.Category, StringTable.CategoryMenuHeader);
            ToolManager.Value.CreateSubMenu(ToolNames.Category, ToolNames.EventCalendar, StringTable.EventCalendarMenuHeader, true);
           

            ToolManager.Value.AddActiveView(ToolNames.Video, RegionNames.MiddleRegion, VideoToolPresenter);
            ToolManager.Value.AddDeactiveView(ToolNames.Video, RegionNames.BottomRegion, FooterPresenter);

            ToolManager.Value.AddActiveView(ToolNames.EventCalendar, RegionNames.MiddleRegion, EventCalendarCategoryToolPresenter);
            ToolManager.Value.AddDeactiveView(ToolNames.EventCalendar, RegionNames.BottomRegion, FooterPresenter);


            //ToolManager.Value.AddActiveView(ToolNames.Deposit, RegionNames.MiddleRegion, DepositToolPresenter);
            //ToolManager.Value.AddDeactiveView(ToolNames.Deposit, RegionNames.BottomRegion, FooterPresenter);
        }
    }
}

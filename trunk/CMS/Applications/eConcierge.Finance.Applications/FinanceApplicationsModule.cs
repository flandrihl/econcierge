using System;
using System.ComponentModel.Composition;
using eConcierge.Finance.Applications.Presenters;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.ToolManagement;
using eConcierge.Foundation.Constants;
using Microsoft.Practices.Composite.MefExtensions.Modularity;
using Microsoft.Practices.Composite.Modularity;

namespace eConcierge.Finance.Applications
{
    [ModuleExport(typeof(FinanceApplicationsModule), DependsOnModuleNames = new[] { "HomeModule" })]
    public class FinanceApplicationsModule:IModule
    {
        [Import]
        private Lazy<ToolManager> ToolManager { get; set; }
        [Import]
        private Lazy<AccountsToolPresenter> AccountsToolPresenter { get; set; }
        [Import]
        private Lazy<IFooterPresenter> FooterPresenter { get; set; }
        [Import]
        private Lazy<DepositToolPresenter> DepositToolPresenter { get; set; }
        public void Initialize()
        {
            ToolManager.Value.CreateMainMenu(ToolNames.Finance, StringTable.FinanceMenuHeader);
            ToolManager.Value.CreateSubMenu(ToolNames.Finance, ToolNames.Accounts, StringTable.AccountsMenuHeader, true);
            ToolManager.Value.CreateSubMenu(ToolNames.Finance, ToolNames.Deposit, StringTable.DepositMenuHeader);

            ToolManager.Value.AddActiveView(ToolNames.Accounts, RegionNames.MiddleRegion, AccountsToolPresenter);
            ToolManager.Value.AddDeactiveView(ToolNames.Accounts, RegionNames.BottomRegion, FooterPresenter);

            ToolManager.Value.AddActiveView(ToolNames.Deposit, RegionNames.MiddleRegion, DepositToolPresenter);
            ToolManager.Value.AddDeactiveView(ToolNames.Deposit, RegionNames.BottomRegion, FooterPresenter);
        }
    }
}

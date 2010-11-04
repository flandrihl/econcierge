using System.ComponentModel.Composition;
using eConcierge.Finance.Applications.Views;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;

namespace eConcierge.Finance.Applications.Presenters
{
    [Export(typeof(AccountsToolPresenter))]
    public class AccountsToolPresenter:ABaseToolPresenter
    {
        [ImportingConstructor]
        public AccountsToolPresenter(IBaseToolView view, IAccountsToolView body)
            : base(view, StringTable.AccountsToolTitle, StringTable.AccountsToolDescription, body)
        {
        }
    }
}

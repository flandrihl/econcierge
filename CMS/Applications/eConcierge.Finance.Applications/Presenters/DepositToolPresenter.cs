using System.ComponentModel.Composition;
using eConcierge.Finance.Applications.Views;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;

namespace eConcierge.Finance.Applications.Presenters
{
    [Export(typeof(DepositToolPresenter))]
    public class DepositToolPresenter:ABaseToolPresenter
    {
        [ImportingConstructor]
        public DepositToolPresenter(IBaseToolView view, IDepositToolView body)
            : base(view, StringTable.DepositToolTitle, StringTable.DepositToolDescription, body)
        {
        }
    }
}

using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Applications.Presenters
{
    [Export(typeof(IFooterPresenter))]
    public class FooterPresenter:APresenter, IFooterPresenter
    {
        [ImportingConstructor]
        public FooterPresenter(IFooterView view) : base(view)
        {
            CopyrightText = StringTable.CopyrightText;
        }
        public string CopyrightText { get; set; }
    }
}

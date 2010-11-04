using System.ComponentModel.Composition;
using eConcierge.Finance.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Finance.Presentation
{
    /// <summary>
    /// Interaction logic for AccountsToolView.xaml
    /// </summary>
    [Export(typeof(IDepositToolView))]
    public partial class DepositToolView: IDepositToolView
    {
        public DepositToolView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

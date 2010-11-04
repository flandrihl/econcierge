using System.ComponentModel.Composition;
using eConcierge.Finance.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Finance.Presentation
{
    /// <summary>
    /// Interaction logic for AccountsToolView.xaml
    /// </summary>
    [Export(typeof(IAccountsToolView))]
    public partial class AccountsToolView: IAccountsToolView
    {
        public AccountsToolView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

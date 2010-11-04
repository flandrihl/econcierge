using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Presentation.Views
{
    /// <summary>
    /// Interaction logic for FooterView.xaml
    /// </summary>
    [Export(typeof(IFooterView))]
    public partial class FooterView: IFooterView
    {
        public FooterView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

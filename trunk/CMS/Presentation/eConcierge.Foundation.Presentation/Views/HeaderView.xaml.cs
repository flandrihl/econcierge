using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Presentation.Views
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    [Export(typeof(IHeaderView))]
    public partial class HeaderView : IHeaderView
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

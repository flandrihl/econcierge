using System.ComponentModel.Composition;
using eConcierge.Foundation.Presenters;
using eConcierge.Home.Applications.Views;

namespace eConcierge.Home.Presentation.Views
{
    /// <summary>
    /// Interaction logic for HomeToolView.xaml
    /// </summary>
    [Export(typeof(IHomeToolView))]
    public partial class HomeToolView: IHomeToolView
    {
        public HomeToolView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

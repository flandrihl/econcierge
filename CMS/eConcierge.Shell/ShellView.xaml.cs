using System.ComponentModel.Composition;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Shell
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    [Export(typeof(ShellView))]
    public partial class ShellView : IView
    {
        [ImportingConstructor]
        public ShellView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

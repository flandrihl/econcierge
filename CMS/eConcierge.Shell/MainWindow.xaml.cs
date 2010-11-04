using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:IView
    {
        public MainWindow()
        {
            InitializeComponent();
            Presenter = new MainWindowPresenter(this);
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

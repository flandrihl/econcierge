using System.ComponentModel.Composition;
using System.Windows.Controls;
using eConcierge.Foundation.Presenters;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Presentation.EventCalendar
{
    /// <summary>
    /// Interaction logic for EcCategoryView.xaml
    /// </summary>

    [Export(typeof(IECCategoryView))]
    public partial class EcCategoryView : UserControl, IECCategoryView
    {
        public EcCategoryView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

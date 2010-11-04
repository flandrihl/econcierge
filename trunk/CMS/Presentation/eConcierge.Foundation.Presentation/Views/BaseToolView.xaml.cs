using System.ComponentModel.Composition;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Presentation.Views
{
    /// <summary>
    /// Interaction logic for BaseToolView.xaml
    /// </summary>
    [Export(typeof(IBaseToolView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BaseToolView : IBaseToolView
    {
        public BaseToolView()
        {
            InitializeComponent();
        }

        public IPresenter Presenter
        {
            set { DataContext = value; }
        }
    }
}

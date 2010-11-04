using System.ComponentModel.Composition;
using System.Windows;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Home.Applications.Views;

namespace eConcierge.Home.Applications.Presenters
{
    [Export(typeof(HomeToolPresenter))]
    public class HomeToolPresenter:ABaseToolPresenter
    {
        [ImportingConstructor]
        public HomeToolPresenter(IBaseToolView view, IHomeToolView body) 
            : base(view, null, null, body)
        {
            TitleVisibility = Visibility.Collapsed;
            DescriptionVisibility = Visibility.Collapsed;
        }
    }
}

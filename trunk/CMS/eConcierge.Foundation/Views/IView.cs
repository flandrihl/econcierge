using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Views
{
    public interface IView
    {
        IPresenter Presenter { set; }
    }
}

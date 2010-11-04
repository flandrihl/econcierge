using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Presenters
{
    public interface IPresenter
    {
        IView View { get; }
    }
}
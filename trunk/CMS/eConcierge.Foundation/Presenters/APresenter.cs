using System.Windows;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Presenters
{
    public abstract class APresenter : NotifyingObject, IPresenter
    {
        protected APresenter(IView view)
        {
            View = view;
            View.Presenter = this;
        }

        public IView View{ get; set;}
        
    }
}
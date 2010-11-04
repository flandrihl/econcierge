using System;
using System.Windows;
using eConcierge.Foundation.Applications.EventArguments;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.Presenters
{
    public abstract class ADialogContentPresenter : APresenter, IPresenter
    {
        protected ADialogContentPresenter(IView view)
            :base(view)
        {
            
        }
        public event EventHandler<GenericEventArgs<DialogResult>> DialogResultEvent;
        public event EventHandler<GenericEventArgs<DialogResult>> DialogClosed;
        
        protected virtual void OnDialogClosed(DialogResult e)
        {            
            if(DialogClosed != null)
                DialogClosed(this, new GenericEventArgs<DialogResult>(e));
        }

        public virtual void OnDialogResultEvent(DialogResult dialogResult)
        {
            if (DialogResultEvent != null)
            {
                DialogResultEvent(this, new GenericEventArgs<DialogResult>(dialogResult));
            }
        }

        public virtual bool OnClosing(DialogResult dialogResult)
        {
            IsVisible = false;
            OnDialogClosed(dialogResult);
            return true;
        }
        
        public bool IsVisible { get; set; }

        public virtual void OnShowing()
        {
            IsVisible = true;
        }

        public virtual void OnActivated()
        {
            
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(ADialogContentPresenter));
    }
}

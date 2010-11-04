using System;
using System.Windows.Input;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.Views
{
    public interface IDialogView : IView
    {
        void Close();
        void SetMainWindowAsOwner();
        bool? ShowDialog();
        void Show();
        event EventHandler Activated;
        event KeyEventHandler KeyDown;
    }
}
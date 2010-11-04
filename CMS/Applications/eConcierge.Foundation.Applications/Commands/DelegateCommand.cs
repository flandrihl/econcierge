using System;
using System.Windows.Input;

namespace eConcierge.Foundation.Applications.Commands
{
    public class DelegateCommand: ICommand
    {
        protected Func<object, bool> CanExecuteDelegate;
        protected Action<object> ExecuteDelegate;
        public DelegateCommand(Action<object> executeDelegate)
            : this(executeDelegate, null)
        {
            
        }
        public DelegateCommand(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate)
        {
            CanExecuteDelegate = canExecuteDelegate;
            ExecuteDelegate = executeDelegate;
        }

        protected DelegateCommand()
        {
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (ExecuteDelegate == null) return;
            ExecuteDelegate(parameter);
        }

        public virtual void RaiseCanExecuteChanged()
        {
            var canExecuteChangedHandler = CanExecuteChanged;
            if (canExecuteChangedHandler != null)
            {
                    canExecuteChangedHandler(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using eConcierge.Foundation.Applications.Commands;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.Presenters
{
    public abstract class DialogConciergePresenter : ADialogContentPresenter
    {
        protected ICommand saveCommand;
        private ICommand cancelCommand;

        public DialogConciergePresenter(IView body)
            : base(body)
        {
        }

        public int Id { get; set; }
        public bool IsEdit { get; set; }


        public ICommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new DelegateCommand(Cancel)); }
        }
        private void Cancel(object obj)
        {
            OnDialogResultEvent(DialogResult.Cancel);
        }


        public ICommand SaveCommand
        {
            get { return saveCommand ?? (saveCommand = new DelegateCommand(Save, CanSaveExecuted)); }
        }

        private bool CanSaveExecuted(object ob)
        {
            return this.IsValid();
        }

        protected abstract void Save(object obj);



    }
}

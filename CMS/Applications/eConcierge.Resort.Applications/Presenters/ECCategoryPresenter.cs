using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using eConcierge.Business;
using eConcierge.Foundation.Applications.Commands;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Model;
using eConcierge.Resort.Applications.Views;
using System.Linq;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(ECCategoryPresenter))]
    public class ECCategoryPresenter : ADialogContentPresenter
    {
        public event EventHandler SaveSuccessEvent;
        private ICommand saveCommand;
      


        [ImportingConstructor]
        public ECCategoryPresenter(IECCategoryView body)
            : base(body)
        {


        }

        public bool IsEdit { get; set; }

        [Required]
        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        [Import]
        private Lazy<EventCalendarCategoryService> EventCalendarCategoryService
        {
            get;
            set;
        }
        public string Description
        {
            get { return GetValue(() => Description); }
            set { SetValue(() => Description, value); }
        }

        public ICommand SaveCommand
        {
            get { return saveCommand ?? (saveCommand = new DelegateCommand(Save, CanSaveExecuted)); }
        }

       

        public int Id { get; set; }

        private bool CanSaveExecuted(object ob)
        {
            return this.IsValid();
        }

       
        private void Save(object obj)
        {
            DTOEventCalendarCategory category = new DTOEventCalendarCategory();
            category.IsNew = !IsEdit;
            category.Id = Id;
            category.Name = Name;
            category.Description = Description;
            if (EventCalendarCategoryService.Value.Save(category))
            {
                OnDialogResultEvent(DialogResult.OK);
            }
        }
    }

}

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
    public class ECCategoryPresenter : DialogConciergePresenter
    {
        public event EventHandler SaveSuccessEvent;


        [ImportingConstructor]
        public ECCategoryPresenter(IECCategoryView body)
            : base(body)
        {


        }

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

        protected override void Save(object obj)
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
        public void InitializeViewModel(DTOEventCalendarCategory category)
        {
            if (category != null)
            {
                Name = category.Name;
                Description = category.Description;
                IsEdit = true;
                Id = category.Id;
            }
            else
            {
                Name = string.Empty;
                Description = string.Empty;
                IsEdit = false;
                Id = 0;
            }
        }
    }

}

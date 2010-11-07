using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using eConcierge.Business;
using eConcierge.Foundation.Applications.Commands;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Model;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(EventCalendarCategoryPresenter))]
    public class EventCalendarCategoryPresenter : ABaseToolPresenter
    {
        private ICommand addCommand;

        private EventCalendarCategoryService _service;
        private EventCalendarCategoryService Service
        {
            get
            {
                return _service ?? (_service = new EventCalendarCategoryService());
            }
        }
        [ImportingConstructor]
        public EventCalendarCategoryPresenter(IBaseToolView view, IEventCalendarCategoryToolView body )
            : base(view, null, null, body)
        {
            TitleVisibility = Visibility.Collapsed;
            DescriptionVisibility = Visibility.Collapsed;
            PrepareView();
        }

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new DelegateCommand(Add);
                }

                return addCommand;
            }
        }

        [Import]
        private Lazy<ECCategoryPresenter> ECCategoryPresenter { get; set; }

        [Import]
        private Lazy<DialogPresenter> DialogPresenter { get; set; }

        private void Add(object obj)
        {
            DialogPresenter.Value.OkButtonCaption = "Save";
            DialogPresenter.Value.ShowModal(ECCategoryPresenter.Value, "EC Category", DialogButton.OKCancel);
        }
      

        private void PrepareView()
        {
            this.Categories = Service.GetEventCalendarCategorys();
        }
        

        public List<DTOEventCalendarCategory> Categories
        {
            private set;
            get;
        }
    }
}

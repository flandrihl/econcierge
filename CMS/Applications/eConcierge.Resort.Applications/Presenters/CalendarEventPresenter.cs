using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using eConcierge.Business;
using eConcierge.Foundation.Applications.Commands;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presentation.Views;
using eConcierge.Model;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(CalendarEventPresenter))]
    public class CalendarEventPresenter : ABaseToolPresenter
    {
         private ICommand addCommand;

         private CalendarEventService _service;
         private CalendarEventService Service
        {
            get
            {
                return _service ?? (_service = new CalendarEventService());
            }
        }
        [ImportingConstructor]
         public CalendarEventPresenter(IBaseToolView view, ICalendarEventToolView body)
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
        private Lazy<ECEventPresenter> ECEventPresenter { get; set; }

      
        private void Add(object obj)
        {
            DialogPresenter dialog = new DialogPresenter(new DialogView());
            ECEventPresenter.Value.InitializeViewModel(null);
            if (dialog.ShowModal(ECEventPresenter.Value, "Event Calendar") == DialogResult.OK)
            {
                PrepareView();
            }
            
        }
        public void Edit(DTOCalendarEvent category)
        {
            //ECCategoryPresenter.Value.InitializeViewModel(category);
            //DialogPresenter dialog = new DialogPresenter(new DialogView());

            //if (dialog.ShowModal(ECCategoryPresenter.Value, "EC Category") == DialogResult.OK)
            //{
            //    PrepareView();
            //}

        }
        public void Delete(int id)
        {
            if(Service.Delete(id))
            {
                PrepareView();
            }
        }

        private void PrepareView()
        {
            Events = new ObservableCollection<DTOCalendarEvent>(Service.GetCalendarEvents());
        }


        //public ObservableCollection<DTOEventCalendarCategory> Categories
        //{
        //    set;
        //    get;
        //}

        public ObservableCollection<DTOCalendarEvent> Events
        {
            get { return GetValue(() => Events); }
            set { SetValue(() => Events, value); }
        }
    }
}

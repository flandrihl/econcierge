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
        public EventCalendarCategoryPresenter(IBaseToolView view, IEventCalendarCategoryToolView body)
            : base(view, null, null, body)
        {
            TitleVisibility = Visibility.Collapsed;
            DescriptionVisibility = Visibility.Collapsed;
            PrepareView();
        }

        void Value_SaveSuccessEvent(object sender, EventArgs e)
        {
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

      
        private void Add(object obj)
        {
            DialogPresenter dialog = new DialogPresenter(new DialogView());

            if (dialog.ShowModal(ECCategoryPresenter.Value, "EC Category") == DialogResult.OK)
            {
                PrepareView();
            }
            
        }
        public void Edit(DTOEventCalendarCategory category)
        {
            ECCategoryPresenter.Value.Name = category.Name;
            ECCategoryPresenter.Value.Description = category.Description;
            ECCategoryPresenter.Value.IsEdit = true;
            ECCategoryPresenter.Value.Id = category.Id;

            DialogPresenter dialog = new DialogPresenter(new DialogView());

            if (dialog.ShowModal(ECCategoryPresenter.Value, "EC Category") == DialogResult.OK)
            {
                PrepareView();
            }

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
            Categories = new ObservableCollection<DTOEventCalendarCategory>(Service.GetEventCalendarCategorys());
        }


        //public ObservableCollection<DTOEventCalendarCategory> Categories
        //{
        //    set;
        //    get;
        //}

        public ObservableCollection<DTOEventCalendarCategory> Categories
        {
            get { return GetValue(() => Categories); }
            set { SetValue(() => Categories, value); }
        }
    }
}

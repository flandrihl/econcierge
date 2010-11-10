using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using eConcierge.Business;
using eConcierge.Foundation.Applications.Presenters;
using eConcierge.Model;
using eConcierge.Resort.Applications.Views;

namespace eConcierge.Resort.Applications.Presenters
{
    [Export(typeof(ECEventPresenter))]
    public class ECEventPresenter : DialogConciergePresenter
    {

        [ImportingConstructor]
        public ECEventPresenter(IECEventView body)
            : base(body)
        {
        }

        [Required]
        public string Title
        {
            get { return GetValue(() => Title); }
            set { SetValue(() => Title, value); }
        }

        [Import]
        private Lazy<CalendarEventService> EventCalendarCategoryService
        {
            get;
            set;
        }
        public string Description
        {
            get { return GetValue(() => Description); }
            set { SetValue(() => Description, value); }
        }
        public DateTime StartDate
        {
            get { return GetValue(() => StartDate); }
            set { SetValue(() => StartDate, value); }
        }

        public DateTime EndDate
        {
            get { return GetValue(() => EndDate); }
            set { SetValue(() => EndDate, value); }
        }

        public string Location
        {
            get { return GetValue(() => Location); }
            set { SetValue(() => Location, value); }
        }

        public double Latitude
        {
            get { return GetValue(() => Latitude); }
            set { SetValue(() => Latitude, value); }
        }
        public double Longitude
        {
            get { return GetValue(() => Longitude); }
            set { SetValue(() => Longitude, value); }
        }

        protected override void Save(object obj)
        {
            DTOCalendarEvent calendarEvent = new DTOCalendarEvent();
            calendarEvent.IsNew = !IsEdit;
            calendarEvent.Id = Id;
            calendarEvent.Title = Title;
            calendarEvent.Description = Description;
            calendarEvent.StartDate = StartDate;
            calendarEvent.EndDate = EndDate;
            calendarEvent.Location = Location;
            calendarEvent.Latitude = Latitude;
            calendarEvent.Longitude = Longitude;
            //if (EventCalendarCategoryService.Value.Save(category))
            {
                OnDialogResultEvent(DialogResult.OK);
            }
        }
        public void InitializeViewModel(DTOEventCalendarCategory category)
        {
            if (category != null)
            {
                Title = category.Name;
                Description = category.Description;
                IsEdit = true;
                Id = category.Id;
            }
            else
            {
                Title = string.Empty;
                Description = string.Empty;
                IsEdit = false;
                Id = 0;
            }
        }
    }
}

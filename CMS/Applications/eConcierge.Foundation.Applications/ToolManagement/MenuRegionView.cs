using System;
using System.ComponentModel.Composition;
using eConcierge.Foundation.Presenters;
using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.ToolManagement
{
    public class MenuRegionView<TPresenter>:IMenuRegionView where TPresenter:IPresenter
    {
        public bool IsActive{ get; set;}
        public string MenuName{ get; set;}

        public string RegionName{ get; set;}

        public IView View
        {
            get { return Presenter.Value.View; }
        }
        [Import]
        public Lazy<TPresenter> Presenter { get; set; }
    }
}
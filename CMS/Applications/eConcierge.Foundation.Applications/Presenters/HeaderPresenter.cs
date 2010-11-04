using System.ComponentModel.Composition;
using System.Windows;
using eConcierge.Foundation.Applications.ToolManagement;
using eConcierge.Foundation.Applications.Views;
using eConcierge.Foundation.Presenters;

namespace eConcierge.Foundation.Applications.Presenters
{
    [Export(typeof(HeaderPresenter))]
    public class HeaderPresenter:APresenter
    {
        [ImportingConstructor]
        public HeaderPresenter(IHeaderView view) : base(view)
        {
            
        }

        [Import]
        public ToolManager ToolManager
        {
            get { return (ToolManager)GetValue(ToolManagerProperty); }
            set { SetValue(ToolManagerProperty, value); }
        }

        public static readonly DependencyProperty ToolManagerProperty =
            DependencyProperty.Register("ToolManager", typeof(ToolManager), typeof(HeaderPresenter));

        
        
    }
}

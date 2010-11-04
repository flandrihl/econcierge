using eConcierge.Foundation.Views;

namespace eConcierge.Foundation.Applications.ToolManagement
{
    public interface IMenuRegionView
    {
        bool IsActive { get; set; }
        string MenuName { get; set; }
        string RegionName { get; set; }
        IView View { get; }
    }
}
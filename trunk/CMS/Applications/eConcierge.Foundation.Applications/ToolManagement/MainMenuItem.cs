using System.Collections.ObjectModel;

namespace eConcierge.Foundation.Applications.ToolManagement
{
    public class MainMenuItem : SubMenuItem
    {
        public MainMenuItem()
        {
            SubMenus = new ObservableCollection<SubMenuItem>();
        }
        public ObservableCollection<SubMenuItem> SubMenus { get; set; }

        public void AddSubMenu(string name, string header)
        {
            AddSubMenu(name,header,false);
        }

        public void AddSubMenu(string name, string header, bool isSelected)
        {
            var menuItem = new SubMenuItem { Name = name, Header = header, IsSelected = isSelected};
            SubMenus.Add(menuItem);
        }
    }
}

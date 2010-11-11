using System.Collections.ObjectModel;
using System;

namespace eConcierge.CMSClient.Code
{
    public class MainMenuItem : SubMenuItem
    {
        public MainMenuItem()
        {
            SubMenus = new ObservableCollection<SubMenuItem>();
        }
        public ObservableCollection<SubMenuItem> SubMenus { get; set; }

        public void AddSubMenu(string name, string header, Action<string> menuclick)
        {
            AddSubMenu(name, header, menuclick,false);
        }

        

        public SubMenuItem AddSubMenu(string name, string header, Action<string> menuclick, bool isSelected)
        {
            var menuItem = new SubMenuItem { Name = name, Header = header, MenuClick=menuclick,  IsSelected = isSelected};
            SubMenus.Add(menuItem);
            return menuItem;
        }
    }
}

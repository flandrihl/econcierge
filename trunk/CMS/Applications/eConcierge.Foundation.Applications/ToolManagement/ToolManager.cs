using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using eConcierge.Foundation.Presenters;
using Microsoft.Practices.Composite.Regions;

namespace eConcierge.Foundation.Applications.ToolManagement
{
    [Export(typeof(ToolManager))]
    public class ToolManager : DependencyObject
    {
        private List<IMenuRegionView> MenuRegionViews { get; set; }

        [Import]
        private IRegionManager RegionManager { get; set; }

        [ImportingConstructor]
        public ToolManager()
        {
            MenuRegionViews = new List<IMenuRegionView>();
            MainMenuItems = new ObservableCollection<MainMenuItem>();
            MainMenuItems.CollectionChanged += MainMenuItemsCollectionChanged;
        }
        void MainMenuItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (MainMenuItem item in e.NewItems)
                    {
                        item.PropertyChanged += MenuitemPropertyChanged;
                        if (item.IsSelected)
                        {
                            SelectedMainMenu = item;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (MainMenuItem item in e.OldItems)
                    {
                        item.PropertyChanged -= MenuitemPropertyChanged;
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void MenuitemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                if (sender is MainMenuItem)
                {
                    var mainMenuItem = (MainMenuItem)sender;
                    if (mainMenuItem.IsSelected)
                    {
                        SelectedMainMenu = mainMenuItem;
                        Activate(SelectedMainMenu);
                    }
                }
                else if (sender is SubMenuItem)
                {
                    var subMenuItem = (SubMenuItem)sender;
                    if (subMenuItem.IsSelected)
                    {
                        Activate(subMenuItem.Name);
                    }
                }
            }
        }

        private void Activate(MainMenuItem mainMenuItem)
        {
            Activate(mainMenuItem.SubMenus.Count == 0
                         ? mainMenuItem.Name
                         : mainMenuItem.SubMenus.First(m => m.IsSelected).Name);
        }

        public void Activate(string toolName)
        {
            foreach(var item in MenuRegionViews.Where(o=>o.MenuName==toolName))
            {
                if (item.IsActive)
                {
                    if (RegionManager.Regions[item.RegionName].Views.Contains(item.View) == false)
                        RegionManager.Regions[item.RegionName].Add(item.View);
                    RegionManager.Regions[item.RegionName].Activate(item.View);
                }
                else if (RegionManager.Regions[item.RegionName].ActiveViews.Contains(item.View))
                    RegionManager.Regions[item.RegionName].Deactivate(item.View);
            }
        }


        public MainMenuItem SelectedMainMenu
        {
            get { return (MainMenuItem)GetValue(SelectedMainMenuProperty); }
            set { SetValue(SelectedMainMenuProperty, value); }
        }

        public static readonly DependencyProperty SelectedMainMenuProperty =
            DependencyProperty.Register("SelectedMainMenu", typeof(MainMenuItem), typeof(ToolManager), new PropertyMetadata(OnPropertyChanged));


        private ObservableCollection<MainMenuItem> MainMenuItems
        {
            get { return (ObservableCollection<MainMenuItem>)GetValue(MainMenuItemsProperty); }
            set { SetValue(MainMenuItemsProperty, value); }
        }
        public static readonly DependencyProperty MainMenuItemsProperty =
            DependencyProperty.Register("MainMenuItems", typeof(ObservableCollection<MainMenuItem>), typeof(ToolManager));

        private static void OnPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs arg)
        {
            var toolManager = (ToolManager)dependencyObject;
            switch (arg.Property.Name)
            {
                case "SelectedMainMenu":
                    if (arg.OldValue != null)
                    {
                        var mainMenuItem = (MainMenuItem)arg.OldValue;
                        foreach (var item in mainMenuItem.SubMenus)
                        {
                            item.PropertyChanged -= toolManager.MenuitemPropertyChanged;
                        }
                    }
                    if (arg.NewValue != null)
                    {
                        var mainMenuItem = (MainMenuItem)arg.NewValue;
                        foreach (var item in mainMenuItem.SubMenus)
                        {
                            item.PropertyChanged += toolManager.MenuitemPropertyChanged;
                        }
                    }
                    break;
            }
        }



        public void AddMainMenuItem(string name, string header, bool isSelected)
        {
            var mainMenuItem = new MainMenuItem { Header = header, Name = name, IsSelected = isSelected };
            AddMainMenuItem(mainMenuItem);
        }

        public void AddMainMenuItem(string name, string header)
        {
            AddMainMenuItem(name, header, false);
        }

        public void AddMainMenuItem(MainMenuItem mainMenuItem)
        {
            MainMenuItems.Add(mainMenuItem);
        }

        public void AddActiveView<TPresenter>(string menuName, string regionName, Lazy<TPresenter> presenter) where TPresenter : IPresenter
        {
            MenuRegionViews.Add(new MenuRegionView<TPresenter>
                                    {
                                        MenuName = menuName, 
                                        RegionName = regionName,  
                                        IsActive = true,
                                        Presenter = presenter
                                    });
        }
        public void AddDeactiveView<TPresenter>(string menuName, string regionName, Lazy<TPresenter> presenter) where TPresenter : IPresenter
        {
            MenuRegionViews.Add(new MenuRegionView<TPresenter>
            {
                MenuName = menuName,
                RegionName = regionName,
                IsActive = false,
                Presenter = presenter
            });
        }

        public MainMenuItem CreateMainMenu(string name, string header)
        {
            return CreateMainMenu(name, header, false);
        }

        private MainMenuItem GetMainMenu(string name)
        {
            return MainMenuItems.SingleOrDefault(m => m.Name == name);
        }

        public void CreateSubMenu(string mainMenuName, string subMenuName, string subMenuHeader, bool isSelected)
        {
            var mainMenu = GetMainMenu(mainMenuName);
            mainMenu.AddSubMenu(subMenuName, subMenuHeader, isSelected);
        }

        public MainMenuItem CreateMainMenu(string name, string header, bool isSelected)
        {
            var mainMenu = GetMainMenu(name);
            if (mainMenu == null)
            {
                mainMenu = new MainMenuItem { Name = name, Header = header, IsSelected = isSelected };
                AddMainMenuItem(mainMenu);
            }
            return mainMenu;
        }

        public void CreateSubMenu(string mainMenuName, string subMenuName, string subMenuHeader)
        {
            CreateSubMenu(mainMenuName,subMenuName,subMenuHeader,false);
        }
    }
}

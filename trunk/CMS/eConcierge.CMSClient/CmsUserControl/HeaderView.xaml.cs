using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using eConcierge.CMSClient.Code;
using System.Linq;

namespace eConcierge.CMSClient.CmsUserControl
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
            MainMenuItems = new ObservableCollection<MainMenuItem>();
            mainMenu.ItemsSource = MainMenuItems;
        }

        public ObservableCollection<MainMenuItem> MainMenuItems
        {
            get { return (ObservableCollection<MainMenuItem>)GetValue(MainMenuItemsProperty); }
            set { SetValue(MainMenuItemsProperty, value); }
        }
        public static readonly DependencyProperty MainMenuItemsProperty =
            DependencyProperty.Register("MainMenuItems", typeof(ObservableCollection<MainMenuItem>), typeof(HeaderView));

       
        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {

        }

        public void AddMainMenu(string name, string header, bool isSelected = false)
        {
            var menuItem = new MainMenuItem();
            menuItem.Header = header;
            menuItem.Name = name;
            menuItem.PropertyChanged += EventCalendarPropertyChanged;
            menuItem.IsSelected = IsSealed;
            MainMenuItems.Add(menuItem);
        }

        public void AddsubMenu(string name,string submenuName, string header, Action<string> menuclickEvent, bool isSelected = false)
        {
            var menuItem = MainMenuItems.FirstOrDefault(m => m.Name.Equals(name));
            if(menuItem != null)
            {
                var submenuItem = menuItem.AddSubMenu(submenuName, header, menuclickEvent, IsSealed);
                submenuItem.PropertyChanged += EventCalendarPropertyChanged;
            }
        }

        void EventCalendarPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                if (sender is MainMenuItem)
                {
                    var mainMenuItem = (MainMenuItem)sender;
                    if (mainMenuItem.IsSelected)
                    {
                        Activate(mainMenuItem);
                    }
                }
                else if (sender is SubMenuItem)
                {
                    var subMenuItem = (SubMenuItem)sender;
                    if (subMenuItem.IsSelected)
                    {
                        subMenuItem.MenuClick(subMenuItem.Name);
                    }
                }
            }
        }

        void MainMenuItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //switch (e.Action)
            //{
            //    case NotifyCollectionChangedAction.Add:
            //        foreach (MainMenuItem item in e.NewItems)
            //        {
            //            item.PropertyChanged += MenuitemPropertyChanged;
            //            if (item.IsSelected)
            //            {
            //                SelectedMainMenu = item;
            //            }
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Remove:
            //        foreach (MainMenuItem item in e.OldItems)
            //        {
            //            item.PropertyChanged -= MenuitemPropertyChanged;
            //        }
            //        break;
            //    case NotifyCollectionChangedAction.Replace:
            //        break;
            //    case NotifyCollectionChangedAction.Move:
            //        break;
            //    case NotifyCollectionChangedAction.Reset:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
        }
       
        private void Activate(MainMenuItem mainMenuItem)
        {
            foreach (SubMenuItem item in subMenu.Items)
            {
                item.IsSelected = false;
            }
            subMenu.ItemsSource = mainMenuItem.SubMenus;
        }
    }
}

using Fakhravari.Class;
using Fakhravari.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Fakhravari
{
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>
            {
                new MasterPageItem() { Title = "Home", Icon = "home.png", TargetType = typeof(HomePage) },
                new MasterPageItem() { Title = "Setting", Icon = "setting.png", TargetType = typeof(SettingPage) },
                new MasterPageItem() { Title = "Help", Icon = "help.png", TargetType = typeof(HelpPage) },
                new MasterPageItem() { Title = "LogOut", Icon = "logout.png", TargetType = typeof(LogoutPage) }
            };

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Xamarin.Forms.Page)Activator.CreateInstance(typeof(HomePage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Xamarin.Forms.Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}

using LynaMarketMobile.Classes;
using LynaMarketMobile.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile
{
    public partial class App : Application
    {
        public App()
        {
            App.Current.UserAppTheme = OSAppTheme.Light;

            InitializeComponent();

            MainPage = new NavigationPage(new NavigatePage());
            NavigationManager.Navigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

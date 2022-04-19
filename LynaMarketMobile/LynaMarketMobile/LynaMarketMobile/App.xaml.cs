using LunaMarketEngine.Entities;
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
            InitializeComponent();

            // Получение данных пользователя.

            int idCustomer;
            string key = "IdCustomer";
            bool contain = Application.Current.Properties.ContainsKey(key);

            if (!contain)
            {
                Application.Current.Properties[key] = 0;
            }

            idCustomer = (int)Application.Current.Properties[key];

            key = "Authorizated";
            contain = Application.Current.Properties.ContainsKey(key);

            if (!contain)
            {
                Application.Current.Properties[key] = false;
            }

            if ((bool)Application.Current.Properties[key])
            {
                CurrentCustomer.Authorizate(idCustomer);
            }

            // Выставление остальных настроек.

            NavigationPage navigatePage = new NavigationPage(new NavigatePage())
            {
                BarBackgroundColor = Xamarin.Forms.Color.FromHex("#8C8C8C")
            };

            MainPage = navigatePage;
            NavigationManager.Navigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
            App.Current.UserAppTheme = OSAppTheme.Light;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

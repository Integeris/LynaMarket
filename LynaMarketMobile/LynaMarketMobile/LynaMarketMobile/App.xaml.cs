using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using LynaMarketMobile.Pages;
using System;
using System.Threading.Tasks;
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

            string key = "IdCustomer";
            bool contain = Application.Current.Properties.ContainsKey(key);

            if (!contain)
            {
                Application.Current.Properties[key] = 0;
            }

            Task.Run(() => Authoriated((int)Application.Current.Properties[key])).Wait();

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

        private async Task Authoriated(int idCustomer)
        {
            if ((await Core.GetCustomerAsync(idCustomer)) != default)
            {
                CurrentCustomer.Authorizate(idCustomer);
            }
        }
    }
}

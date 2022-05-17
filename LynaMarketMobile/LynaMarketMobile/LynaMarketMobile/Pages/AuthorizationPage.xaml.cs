using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public bool Authorizated { get; set; }

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void EntryButtonOnClicked(object sender, EventArgs e)
        {
            Customer customer = await Core.GetCustomerAsync(LoginEntry.Text);

            if (PasswordEntry.Text != customer.Password)
            {
                InfoViewer.ShowError(this, "Логин и/или пароль не верен(ы).");
                return;
            }

            CurrentCustomer.Authorizate(customer.IdCustomer);
            Authorizated = true;
            this.Dispatcher.BeginInvokeOnMainThread(() => NavigationManager.PopPage());
        }

        private async void RecoverPasswordButtonOnClicked(object sender, EventArgs e)
        {
            Customer customer = await Core.GetCustomerAsync(LoginEntry.Text);

            if (customer == default)
            {
                InfoViewer.ShowError(this, "Такого пользователя не существует.");
                return;
            }

            NavigationManager.PushPage(new RecoverPasswordPage(customer));
        }
    }
}
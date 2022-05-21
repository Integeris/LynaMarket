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
    public partial class AuthorizationProfilePage : ContentPage
    {
        private readonly ProfilePage profilePage;

        public AuthorizationProfilePage(ProfilePage profilePage)
        {
            InitializeComponent();
            this.profilePage = profilePage;

            LoadCustomer();
        }

        private async void LoadCustomer()
        {
            Customer customer = await Core.GetCustomerAsync(CurrentCustomer.IdCustomer);

            LoginEntry.Text = customer.Login;
            PasswordEntry.Text = customer.Password;
            EmailEntry.Text = customer.Email;
            FirstNameEntry.Text = customer.FirstName;
            SecondNameEntry.Text = customer.SecondName;
            PhoneEntry.Text = customer.Phone;
        }

        private void ExitButtonOnClicked(object sender, EventArgs e)
        {
            CurrentCustomer.Exit();
            profilePage.LoadContent();
        }

        private void EditButtonOnClicked(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage();
            editProfilePage.Disappearing += EditProfilePageOnDisappearing;
            NavigationManager.PushPage(editProfilePage);
        }

        private void EditProfilePageOnDisappearing(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = (EditProfilePage)sender;

            if (editProfilePage.Apply)
            {
                LoadCustomer();
                InfoViewer.ShowInfo(Application.Current.MainPage, "Данные успешно изменены.");
            }
        }

        private void HistoryButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new HistoryPage());
        }
    }
}
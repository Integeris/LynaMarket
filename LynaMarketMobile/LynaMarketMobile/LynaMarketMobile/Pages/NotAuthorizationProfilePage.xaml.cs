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
    public partial class NotAuthorizationProfilePage : ContentPage
    {
        private ProfilePage profilePage;

        public NotAuthorizationProfilePage(ProfilePage profilePage)
        {
            InitializeComponent();

            this.profilePage = profilePage;
        }

        private void AboutButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new AboutPage());
        }

        private void AuthorizationButtonOnClicked(object sender, EventArgs e)
        {
            AuthorizationPage authorizationPage = new AuthorizationPage();
            authorizationPage.Disappearing += AuthorizationPageOnDisappearing;

            NavigationManager.PushPage(authorizationPage);
        }

        private void RegistrationButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new RegistrationPage());
        }

        private void AuthorizationPageOnDisappearing(object sender, EventArgs e)
        {
            AuthorizationPage authorizationPage = (AuthorizationPage)sender;

            if (authorizationPage.Authorizated)
            {
                InfoViewer.ShowInfo(this, "Вы успешно авторизировались.");
                profilePage.LoadContent();
            }
        }
    }
}
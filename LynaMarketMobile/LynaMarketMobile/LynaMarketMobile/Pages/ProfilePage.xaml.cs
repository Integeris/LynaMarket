using LunaMarketEngine;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadContent();
        }

        public void LoadContent()
        {
            if (CurrentCustomer.Authorizated)
            {
                MainContentView.Content = new AuthorizationProfilePage(this).Content;
            }
            else
            {
                MainContentView.Content = new NotAuthorizationProfilePage(this).Content;
            }
        }
    }
}
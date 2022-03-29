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
        }

        private async void ProfileButtonOnClicked(object sender, EventArgs e)
        {
            await ((Page)this.Parent.Parent).Navigation.PushAsync(new AuthorizationPage());
            //Navigation.PushAsync(new AuthorizationPage());
        }
    }
}
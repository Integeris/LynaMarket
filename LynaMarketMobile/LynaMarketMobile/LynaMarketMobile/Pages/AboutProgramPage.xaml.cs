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
    public partial class AboutProgramPage : ContentPage
    {
        public AboutProgramPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            return base.OnBackButtonPressed();
        }
    }
}
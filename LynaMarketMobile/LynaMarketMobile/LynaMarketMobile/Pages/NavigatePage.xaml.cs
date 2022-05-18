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
    public partial class NavigatePage : ContentPage
    {
        private Button selectedButton;

        public NavigatePage()
        {
            Core.Disconnect += CoreOnDisconnect;
            Core.Connect += CoreOnConnect;

            InitializeComponent();

            selectedButton = MainButton;
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton == selectedButton)
            {
                return;
            }

            switch (clickedButton.Text)
            {
                case "Главная":
                    MainCaruselView.Position = 0;
                    break;
                case "Каталог":
                    MainCaruselView.Position = 1;
                    break;
                case "Корзина":
                    MainCaruselView.Position = 2;
                    break;
                default:
                    MainCaruselView.Position = 3;
                    break;
            }
        }

        private void MainCaruselViewOnPositionChanged(object sender, PositionChangedEventArgs e)
        {
            Button clickedButton;

            switch (e.CurrentPosition)
            {
                case 0:
                    clickedButton = MainButton;
                    break;
                case 1:
                    clickedButton = CatalogButton;
                    break;
                case 2:
                    clickedButton = BasketButton;
                    break;
                default:
                    clickedButton = ProfileButton;
                    break;
            }

            clickedButton.Style = (Style)App.Current.Resources["SelectedNavigationButton"];
            selectedButton.Style = (Style)App.Current.Resources["NavigationButton"];
            selectedButton = clickedButton;
        }

        private void CoreOnConnect()
        {
            this.Dispatcher.BeginInvokeOnMainThread(() => this.Navigation.PopAsync(false));
        }

        private void CoreOnDisconnect()
        {
            this.Dispatcher.BeginInvokeOnMainThread(() => this.Navigation.PushAsync(new FailConnectionPage(), false));
        }
    }
}
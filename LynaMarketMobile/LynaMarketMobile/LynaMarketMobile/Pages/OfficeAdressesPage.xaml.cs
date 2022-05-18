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
    public partial class OfficeAdressesPage : ContentPage
    {
        public bool Selected { get; set; }

        public OfficeAddress OfficeAddress
        {
            get => (OfficeAddress)OfficeAddressesListView.SelectedItem;
        }

        public OfficeAdressesPage()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(LoadData);
        }

        private async void LoadData()
        {
            List<OfficeAddress> officeAddresses = await Core.GetOfficeAddressesAsync();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                OfficeAddressesListView.ItemsSource = officeAddresses;
            });
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PopPage();
        }

        private void SelectButtonOnClicked(object sender, EventArgs e)
        {
            if (OfficeAddressesListView.SelectedItem == default)
            {
                InfoViewer.ShowError(this, "Вы не выбрали место получения заказа.");
                return;
            }

            Selected = true;
            NavigationManager.PopPage();
        }
    }
}
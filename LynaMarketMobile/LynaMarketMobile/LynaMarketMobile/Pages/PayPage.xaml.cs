﻿using LunaMarketEngine;
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
    public partial class PayPage : ContentPage
    {
        private readonly decimal cost;

        public bool Result { get; set; }

        public PayPage(decimal cost)
        {
            InitializeComponent();

            this.cost = cost;
            CostLabel.BindingContext = this.cost;
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            List<DeliveryType> deliveryTypes = await Core.GetDeliveryTypesAsync();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                DevelopTypeListView.ItemsSource = deliveryTypes;
            });
        }

        private void DevelopTypeListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DeliveryType deliveryType = (DeliveryType)e.SelectedItem;

            switch (deliveryType.Title)
            {
                case "Самовывоз":
                    AddressEntry.Text = String.Empty;
                    AddressEntry.IsReadOnly = true;
                    SelectAddressButton.IsVisible = true;
                    break;
                default:
                    AddressEntry.Text = String.Empty;
                    AddressEntry.IsReadOnly = false;
                    SelectAddressButton.IsVisible = false;
                    break;
            }
        }

        private void SelectAddressButtonOnClicked(object sender, EventArgs e)
        {
            OfficeAdressesPage officeAdressesPage = new OfficeAdressesPage();
            officeAdressesPage.Disappearing += OfficeAdressesPageOnDisappearing;
            NavigationManager.PushPage(officeAdressesPage);
        }

        private void OfficeAdressesPageOnDisappearing(object sender, EventArgs e)
        {
            OfficeAdressesPage officeAdressesPage = (OfficeAdressesPage)sender;

            if (officeAdressesPage.Selected)
            {
                AddressEntry.Text = officeAdressesPage.OfficeAddress.Title;
            }
        }

        private async void ApplyButtonOnClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AddressEntry.Text))
            {
                InfoViewer.ShowError(this, "Адрес доставки не введён.");
                return;
            }

            ApplyButton.IsEnabled = false;
            AddressEntry.IsEnabled = false;
            SelectAddressButton.IsEnabled = false;

            DeliveryType deliveryType = (DeliveryType)DevelopTypeListView.SelectedItem;
            OrderStatus orderStatus = await Core.GetOrderStatusAsync("В обработке");

            Order order = new Order()
            {
                Adress = AddressEntry.Text,
                Date = DateTime.Now,
                IdDeliveryType = deliveryType.IdDeliveryType,
                IdOrderStatus = orderStatus.IdOrderStatus,
                IdCustomer = CurrentCustomer.IdCustomer
            };

            int idOrder = await Core.AddOrder(order.IdCustomer, order.IdOrderStatus, order.IdDeliveryType, order.Date, order.Adress);

            foreach (BasketProductView item in BasketManager.BasketProductViews)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    IdProduct = item.IdProduct,
                    IdOrder = idOrder,
                    Price = item.Price,
                    Amount = item.Amount
                };

                await Core.AddOrderProduct(orderProduct.IdOrder, orderProduct.IdProduct, orderProduct.Price, orderProduct.Amount);
            }

            Result = true;
            NavigationManager.PopPage();
        }
    }
}
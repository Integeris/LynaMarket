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
    public partial class OrderPage : ContentPage
    {
        private readonly int idOrder;

        public OrderPage(int idOrder)
        {
            InitializeComponent();

            this.idOrder = idOrder;
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(LoadData);
        }

        private async void LoadData()
        {
            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                ProductsListView.BeginRefresh();
            });

            Order order = await Core.GetOrderAsync(idOrder);
            OrderView orderView = new OrderView()
            {
                IdOrder = order.IdOrder,
                OrderStatus = (await order.GetOrderStatusAsync()).Title,
                PaymentMethod = (await order.GetPaymentMethod()).Title,
                PayStatus = (await order.GetPayStatus()).Title,
                DeliveryType = (await order.GetDeliveryTypeAsync()).Title,
                Address = order.Adress,
                Price = 0
            };
            
            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                this.Title = $"№{order.IdOrder} – {order.Date}";
            });

            List<ProductListView> productViews = new List<ProductListView>();
            List<OrderProduct> orderProducts = await order.GetOrderProductsAsync();

            foreach (OrderProduct item in orderProducts)
            {
                Product product = await item.GetProductAsync();
                ProductListView productListView = new ProductListView(product.IdProduct, product.Title, (await product.GetManufacturerAsync()).Title,
                    item.Price, item.Amount, product.Description, (await product.GetProductPhotoAsync()).FirstOrDefault().Image);

                productViews.Add(productListView);
                orderView.Price += item.Amount * item.Price;
            }

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                this.BindingContext = orderView;
                ProductsListView.ItemsSource = productViews;
                ProductsListView.EndRefresh();
            });
        }
    }
}
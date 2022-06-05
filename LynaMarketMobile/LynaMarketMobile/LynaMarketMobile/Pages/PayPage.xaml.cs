using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LunaMarketEngine.Payment;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            List<PaymentMethod> paymentMethods = await Core.GetPaymentMethodsAsync();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                DevelopTypeListView.ItemsSource = deliveryTypes;
                PaymentMethodListView.ItemsSource= paymentMethods;
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
            try
            {
                if (String.IsNullOrWhiteSpace(AddressEntry.Text))
                {
                    throw new Exception("Адрес доставки не введён.");
                }
                else if (PaymentMethodListView.SelectedItem == null)
                {
                    throw new Exception("Выберите способ оплаты.");
                }
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(this, ex.Message);
                return;
            }

            try
            {
                ApplyButton.IsEnabled = false;
                AddressEntry.IsEnabled = false;
                SelectAddressButton.IsEnabled = false;

                Customer customer = await Core.GetCustomerAsync(CurrentCustomer.IdCustomer);

                List<Product> products = new List<Product>();

                products = BasketManager.BasketProductViews.AsParallel().Select(async basketProduct =>
                {
                    Product product = await Core.GetProductAsync(basketProduct.IdProduct);

                    if (product.Amount < basketProduct.Amount)
                    {
                        throw new Exception($"К сожелению, товара '{product.Title}' не осталось в количестве '{basketProduct.Amount}.\nОсталось всего {product.Amount} шт.'");
                    }

                    return product;
                }).Select(task => task.Result).ToList();

                DeliveryType deliveryType = (DeliveryType)DevelopTypeListView.SelectedItem;
                PaymentMethod paymentMethod = (PaymentMethod)PaymentMethodListView.SelectedItem;
                OrderStatus orderStatus = await Core.GetOrderStatusAsync("В обработке");

                int idOrder = -1;

                try
                {
                    Order order = new Order()
                    {
                        Address = AddressEntry.Text,
                        Date = DateTime.Now,
                        IdDeliveryType = deliveryType.IdDeliveryType,
                        IdPaymentMethod = paymentMethod.IdPaymentMethod,
                        IdPayStatus = 2,
                        IdOrderStatus = orderStatus.IdOrderStatus,
                        IdCustomer = customer.IdCustomer
                    };

                    idOrder = await Core.AddOrder(order.IdCustomer, order.IdOrderStatus, order.IdPaymentMethod, order.IdPayStatus, 
                        order.IdDeliveryType, order.Date, order.Address);

                    decimal amount = 0;

                    foreach (BasketProductView item in BasketManager.BasketProductViews)
                    {
                        OrderProduct orderProduct = new OrderProduct()
                        {
                            IdProduct = item.IdProduct,
                            IdOrder = idOrder,
                            Price = item.ProductPrice,
                            Amount = item.Amount
                        };

                        amount += orderProduct.Price * orderProduct.Amount;
                        await Core.AddOrderProduct(orderProduct.IdOrder, orderProduct.IdProduct, orderProduct.Price, orderProduct.Amount);
                    }

                    if (((PaymentMethod)PaymentMethodListView.SelectedItem).IdPaymentMethod == 1)
                    {
                        // Если оплата онлайн
                        SberClient sberClient = new SberClient();
                        RegistrationResponce registrationResponce = sberClient.RegistrationOrder(idOrder, (int)(amount * 100), customer.Phone, customer.Email);

                        if (registrationResponce.ErrorCode != null && registrationResponce.ErrorCode != "0")
                        {
                            throw new Exception(registrationResponce.ErrorMessage);
                        }

                        await Browser.OpenAsync(registrationResponce.FormUrl);

                        Core.UpdateOrder(idOrder, customer.IdCustomer, orderStatus.IdOrderStatus, paymentMethod.IdPaymentMethod, 
                            2, deliveryType.IdDeliveryType, DateTime.Now, AddressEntry.Text);
                    }

                    foreach (var item in products)
                    {
                        Core.UpdateProduct(item.IdProduct, item.IdManufacturer, item.IdProductCategory, item.IdColor, item.IdMaterial, item.Title,
                                item.Price, item.Amount - BasketManager.BasketProductViews.FirstOrDefault(i => item.IdProduct == i.IdProduct).Amount, item.Height,
                                item.Width, item.Depth, item.Description, item.Deleted);
                    }

                    Result = true;
                }
                catch (Exception ex)
                {
                    if (idOrder != -1)
                    {
                        Core.DeleteOrder(idOrder);
                    }

                    throw ex;
                }
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(this, ex.Message);
            }

            NavigationManager.PopPage();
        }

        private void PayInfoButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new PayInfoPage());
        }
    }
}
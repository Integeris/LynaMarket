using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : ContentPage, INotifyPropertyChanged
    {
        private decimal cost;
        public new event PropertyChangedEventHandler PropertyChanged;

        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        public BasketPage()
        {
            InitializeComponent();

            BasketListView.ItemsSource = BasketManager.BasketProductViews;
            BasketManager.BasketProductViews.CollectionChanged += BasketProductViewsOnCollectionChanged;
        }

        private void ProductViewOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateCost();
        }

        private void BasketProductViewsOnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (BasketProductView item in e.NewItems)
                {
                    item.PropertyChanged += ProductViewOnPropertyChanged;
                }
            }

            UpdateCost();
        }

        private void UpdateCost()
        {
            Cost = BasketManager.BasketProductViews.Sum(i => i.Price);
        }

        private void BasketProductOnDelete(object sender, DeleteItemArgs e)
        {
            BasketProductView productView = (BasketProductView)e.Item;
            BasketManager.BasketProductViews.Remove(productView);
        }

        public new void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ViewCellOnTapped(object sender, EventArgs e)
        {
            ProductPage productPage = new ProductPage(((BasketProductView)((ViewCell)sender).BindingContext).IdProduct);
            NavigationManager.PushPage(productPage);
        }

        private void PayButtonOnClicked(object sender, EventArgs e)
        {
            try
            {
                if (!CurrentCustomer.Authorizated)
                {
                    throw new Exception("Вы не авторизированы.");
                }
                else if (BasketManager.BasketProductViews.Count == 0)
                {
                    throw new Exception("Вы не выбрали ни одного товара.");
                }
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(App.Current.MainPage, ex.Message);
                return;
            }

            PayPage payPage = new PayPage(cost);
            payPage.Disappearing += PayPageOnDisappearing;
            NavigationManager.PushPage(payPage);
        }

        private async void PayPageOnDisappearing(object sender, EventArgs e)
        {
            PayPage payPage = (PayPage)sender;

            if (payPage.Result)
            {
                try
                {
                    Customer customer = await Core.GetCustomerAsync(CurrentCustomer.IdCustomer);
                    MailSender mailSender = new MailSender(customer.Email)
                    {
                        Subject = "ООО <<Луна>>. Спасибо за покупку в нашем магазине!",
                        Body = "Спасибо Вам за покупку в нашем магазине. Надеюсь, Вам понравятся наши товары."
                    };

                    mailSender.SendAsync();

                    BasketManager.BasketProductViews.Clear();
                    InfoViewer.ShowInfo((NavigationPage)App.Current.MainPage, "Вы успешно оформили заказ. Надеюсь, Вам понравятся наши товары.");
                }
                catch (Exception) { }
            }
        }

        private async void ContentPageOnAppearing(object sender, EventArgs e)
        {
            for (int i = 0; i < BasketManager.BasketProductViews.Count; i++)
            {
                Product product = await Core.GetProductAsync(BasketManager.BasketProductViews[i].IdProduct);
                BasketManager.BasketProductViews[i] = new BasketProductView()
                {
                    IdProduct = product.IdProduct,
                    ProductPrice = product.Price,
                    Title = product.Title,
                    Image = (await product.GetProductPhotoAsync()).FirstOrDefault().Image,
                    Amount = 1,
                    MaxAmount = product.Amount
                };

                BasketManager.BasketProductViews[i].OnPropertyChanged();
            }
        }
    }
}
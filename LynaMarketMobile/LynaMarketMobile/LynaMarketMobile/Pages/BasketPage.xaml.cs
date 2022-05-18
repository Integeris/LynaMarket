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
            List<Product> products = new List<Product>();

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

                products = BasketManager.BasketProductViews.AsParallel().Select(async basketProduct =>
                {
                    Product product = await Core.GetProductAsync(basketProduct.IdProduct);

                    if (product.Amount < basketProduct.Amount)
                    {
                        throw new Exception($"К сожелению, товара '{product.Title}' не осталось в количестве '{basketProduct.Amount}.\nОсталось всего {product.Amount} шт.'");
                    }

                    return product;
                }).Select(task => task.Result).ToList();
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

        private void PayPageOnDisappearing(object sender, EventArgs e)
        {
            PayPage payPage = (PayPage)sender;

            if (payPage.Result)
            {
                BasketManager.BasketProductViews.Clear();
                InfoViewer.ShowInfo(App.Current.MainPage, "Вы успешно оформили заказ.");
            }
        }
    }
}
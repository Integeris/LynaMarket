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
        private readonly ObservableCollection<BasketProductView> basketProductViews = new ObservableCollection<BasketProductView>();
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

            BasketListView.ItemsSource = basketProductViews;
            basketProductViews.CollectionChanged += BasketProductViewsOnCollectionChanged;
            LoadDataAsync();
        }

        public void LoadDataAsync()
        {
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                BasketListView.BeginRefresh();
            });

            List<MultiProperty> multiProperties = null;

            if (BasketManager.ProductIds.Count > 0)
            {
                multiProperties = new List<MultiProperty>()
            {
                new MultiProperty("IdProduct", BasketManager.ProductIds.Select(id => (object)id).ToList())
            };
            }

            List<SortingProperty> sortingProperties = new List<SortingProperty>()
            {
                new SortingProperty("Title")
            };

            List<Product> products = BasketManager.ProductIds.Count == 0 ? new List<Product>() : 
                await Core.GetProductsAsync(multiProperties: multiProperties, sortingProperties: sortingProperties);

            for (int i = 0; i < basketProductViews.Count; i++)
            {
                Product product = products.FirstOrDefault(innerProduct => innerProduct.IdProduct == basketProductViews[i].IdProduct);

                if (product == null)
                {
                    basketProductViews.Remove(basketProductViews[i]);
                    i--;
                }
            }

            foreach (Product product in products)
            {
                BasketProductView basketProductView = basketProductViews.FirstOrDefault(i => i.IdProduct == product.IdProduct);

                if (basketProductView != null)
                {
                    basketProductView.Title = product.Title;
                    basketProductView.MaxAmount = product.Amount;
                    basketProductView.Image = basketProductView.Image;
                    basketProductView.ProductPrice = product.Price;
                }
                else
                {
                    BasketProductView productView = new BasketProductView
                    {
                        IdProduct = product.IdProduct,
                        Title = product.Title,
                        Amount = 1,
                        MaxAmount = product.Amount,
                        Image = (await product.GetProductPhotoAsync()).First().Image,
                        ProductPrice = product.Price
                    };

                    productView.PropertyChanged += ProductViewOnPropertyChanged;
                    basketProductViews.Add(productView);
                }
            }

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                BasketListView.EndRefresh();
            });
        }

        private void ProductViewOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateCost();
        }

        private void BasketProductViewsOnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            UpdateCost();
        }

        private void UpdateCost()
        {
            Cost = basketProductViews.Sum(i => i.Price);
        }

        private void BasketProductOnDelete(object sender, DeleteItemArgs e)
        {
            BasketProductView productView = (BasketProductView)e.Item;
            BasketManager.ProductIds.Remove(productView.IdProduct);
            basketProductViews.Remove(productView);
        }

        public new void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ViewCellOnTapped(object sender, EventArgs e)
        {
            ProductPage productPage = new ProductPage(((BasketProductView)((ViewCell)sender).BindingContext).IdProduct);
            productPage.Disappearing += ProductPageOnDisappearing;
            NavigationManager.PushPage(productPage);
        }

        private void ProductPageOnDisappearing(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
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
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(() => LoadData());
        }

        public async void LoadData()
        {
            List<ProductCategory> productCategories = await Core.GetProductCategoriesAsync();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                CatalogListView.ItemsSource = productCategories;
            });
        }

        private void ListViewButtonOnClicked(object sender, EventArgs e)
        {
            ProductCategory productCategory = (ProductCategory)((Button)sender).Parent.BindingContext;
            ProductsPage productsPage = new ProductsPage(productCategory);
            productsPage.Disappearing += ProductsPageOnDisappearing;
            NavigationManager.PushPage(productsPage);
        }

        private void ProductsPageOnDisappearing(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
    }
}
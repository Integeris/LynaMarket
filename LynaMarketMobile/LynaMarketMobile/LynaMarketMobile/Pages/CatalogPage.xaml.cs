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
            LoadCategeries();
        }

        public async void LoadCategeries()
        {
            List<ProductCategory> productCategories = await Core.GetProductCategoriesAsync();
            CatalogListView.ItemsSource = productCategories;
        }

        private void ListViewButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new ProductsPage());
        }
    }
}
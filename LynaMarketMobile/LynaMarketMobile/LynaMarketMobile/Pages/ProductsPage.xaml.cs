using LunaMarketEngine;
using LunaMarketEngine.Entities;
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
    public partial class ProductsPage : ContentPage
    {
        private Filter filter = new Filter()
        {
            Skip = 0,
            Take = 20
        };

        public ProductsPage(int idCategory)
        {
            InitializeComponent();
        }

        private async void LoadData(int idCategory)
        {
            filter.ProductCategories = new List<ProductCategory>()
            {
                await Core.GetProductCategoryAsync(idCategory)
            };
        }

        private void SortButtonOnClicked(object sender, EventArgs e)
        {

        }

        private void FilterButtonOnClicked(object sender, EventArgs e)
        {

        }
    }
}
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
    public partial class ProductsPage : ContentPage
    {
        private List<ProductView> productViews = new List<ProductView>();
        private Filter filter = new Filter()
        {
            Skip = 0,
            Take = 20
        };

        public ProductsPage(ProductCategory productCategory)
        {
            InitializeComponent();
            filter.ProductCategories = new List<ProductCategory> { productCategory };
            LoadData();
        }

        private async void LoadData()
        {
            List<Product> products = await filter.GetProducts();
            productViews = products.Select(product => new ProductView(product.IdProduct, product.Title, product.ProductPhotos.First().Image)).ToList();
            ProductsListView.ItemsSource = productViews;
        }

        private void SortButtonOnClicked(object sender, EventArgs e)
        {

        }

        private void FilterButtonOnClicked(object sender, EventArgs e)
        {

        }
    }
}
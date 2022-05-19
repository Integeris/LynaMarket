using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private List<ProductListView> productViews = new List<ProductListView>();

        private readonly Filter filter = new Filter()
        {
            FromAmount = 1,
            Deleted = false,
            MaxWordLen = 2,
            MaxStringLen = 10,
            Skip = 0,
            Take = 5,
            SortingProperties = new List<SortingProperty>()
            {
                new SortingProperty("Price")
            }
        };

        public bool IsClosing { get; private set; } = true;

        public ProductsPage(string searchText)
        {
            InitializeComponent();

            MainSearchBar.Text = searchText;
            MainNavigator.ItemsCountOnPage = filter.Take;
            LoadDataAsync();
        }

        public ProductsPage(ProductCategory productCategory)
        {
            InitializeComponent();

            filter.ProductCategories = new List<ProductCategory> { productCategory };
            MainNavigator.ItemsCountOnPage = filter.Take;
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            ProductsListView.ItemsSource = null;
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            Device.BeginInvokeOnMainThread(() => ProductsListView.BeginRefresh());
            ProductsListView.ItemsSource = null;

            if (!String.IsNullOrWhiteSpace(MainSearchBar.Text))
            {
                string tmp = Regex.Replace(MainSearchBar.Text, @"[\s\.();,:\-/\\]+", " ");
                filter.Title = Regex.Replace(tmp, @"\s{2,}", "").Trim();
            }
            else
            {
                filter.Title = null;
            }

            int navigatorPage = MainNavigator.CurrentPage;
            int itemsCount = (int)await Core.GetProductCountAsync(filter.GetStaticProperties,
                    filter.GetBetweenProperties, filter.GetMultiProperties, filter.LivensgtainProperty);

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                MainNavigator.ItemsCount = itemsCount;
            });

            int pageCount = (int)Math.Ceiling((double)itemsCount / filter.Take);

            if (pageCount == 0)
            {
                pageCount++;
            }

            int skip = ((navigatorPage < pageCount ? navigatorPage : pageCount) - 1) * filter.Take;
            filter.Skip = skip;

            List<Product> products = await filter.GetProducts();
            productViews = new List<ProductListView>();

            productViews = products.AsParallel().Select(async product =>
            {
                return new ProductListView(product.IdProduct, product.Title, (await product.GetManufacturerAsync()).Title, product.Price,
                    product.Amount, product.Description, (await product.GetProductPhotoAsync()).FirstOrDefault().Image);
            }).Select(i => i.Result).ToList();

            if (products.Count == 0)
            {
                await Task.Delay(100);
                EmptySearchLabel.Opacity = 1;
            }
            else
            {
                EmptySearchLabel.Opacity = 0;
            }

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                ProductsListView.ItemsSource = productViews;
            });
            
            Device.BeginInvokeOnMainThread(() => ProductsListView.EndRefresh());
        }

        private void SortButtonOnClicked(object sender, EventArgs e)
        {
            SortingSettingsPage sortingSettingsPage = new SortingSettingsPage(filter);
            sortingSettingsPage.Disappearing += SettingspagesOnDisappearing;
            IsClosing = false;
            NavigationManager.PushPage(sortingSettingsPage);
        }

        private void FilterButtonOnClicked(object sender, EventArgs e)
        {
            FilterPage filterPage = new FilterPage(filter);
            filterPage.Disappearing += SettingspagesOnDisappearing;
            IsClosing = false;
            NavigationManager.PushPage(filterPage);
        }

        private void SettingspagesOnDisappearing(object sender, EventArgs e)
        {
            IsClosing = true;
            LoadDataAsync();
        }

        private void ViewCellOnTapped(object sender, EventArgs e)
        {
            ViewCell viewCell = (ViewCell)sender;
            ProductListView productView = (ProductListView)viewCell.BindingContext;
            ProductPage productPage = new ProductPage(productView.IdProduct);
            productPage.Disappearing += ProductPageOnDisappearing;
            IsClosing = false;
            NavigationManager.PushPage(productPage);
        }

        private void TapGestureRecognizerOnTapped(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            ViewCell viewCell = (ViewCell)label.Parent.Parent.Parent;
            ViewCellOnTapped(viewCell, e);
        }

        private void ProductPageOnDisappearing(object sender, EventArgs e)
        {
            IsClosing = true;
            LoadDataAsync();
        }

        private void MainSearchBarOnSearchButtonPressed(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void MainSearchBarOnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(MainSearchBar.Text))
            {
                LoadDataAsync();
                MainSearchBar.Unfocus();
            }
        }

        private void MainNavigatorOnSelectPage(object sender, SelectPageEventArgs e)
        {
            LoadDataAsync();
        }
    }
}
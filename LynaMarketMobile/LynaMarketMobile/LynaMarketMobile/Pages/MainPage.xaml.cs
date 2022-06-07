using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            CatalogPage catalogPage = new CatalogPage();
            catalogPage.CloseCatalog += CatalogPageOnCloseCatalog;
            ListView listView = (ListView)catalogPage.Content.FindByName("CatalogListView");
            listView.ItemAppearing += ListViewOnItemAppearing;

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                CatalogContentView.Content = listView;
            });

            List<SortingProperty> sortingProperties = new List<SortingProperty>()
            {
                new SortingProperty("Date")
            };

            List<NewsView> newNews = (await Core.GetNewsAsync(5, sortingProperties))
                .AsParallel().Select(innerNews => new NewsView(innerNews)).ToList();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                NewsCarouselView.ItemsSource = newNews;
                ((NavigationPage)Application.Current.MainPage).ForceLayout();
            });
        }

        private void CatalogPageOnCloseCatalog()
        {
            LoadDataAsync();
        }

        private void ListViewOnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            ListView listView = (ListView)sender;
            CatalogContentView.HeightRequest = listView.RowHeight * (e.ItemIndex + 1) + 5;
        }

        private void NewsButtonOnClicked(object sender, EventArgs e)
        {
            NewsView newsView = (NewsView)NewsCarouselView.CurrentItem;
            NewsPage newsPage = new NewsPage(newsView.IdNews);
            newsPage.Disappearing += PagesOnDisappearing;
            NavigationManager.PushPage(newsPage);
        }

        private void MainSearchBarOnSearchButtonPressed(object sender, EventArgs e)
        {
            ProductsPage productsPage = new ProductsPage(MainSearchBar.Text);
            productsPage.Disappearing += PagesOnDisappearing;
            NavigationManager.PushPage(productsPage);
        }

        private void PagesOnDisappearing(object sender, EventArgs e)
        {
            MainSearchBar.Text = String.Empty;
            LoadDataAsync();
        }

        private void AboutProgramButtonOnClicked(object sender, EventArgs e)
        {
            AboutProgramPage aboutProgramPage = new AboutProgramPage();
            aboutProgramPage.Disappearing += AboutOnDisappearing;
            NavigationManager.PushPage(aboutProgramPage);
        }

        private void AboutCompanyButtonOnClicked(object sender, EventArgs e)
        {
            AboutCompanyPage aboutCompanyPage = new AboutCompanyPage();
            aboutCompanyPage.Disappearing += AboutOnDisappearing;
            NavigationManager.PushPage(aboutCompanyPage);
        }

        private void AboutOnDisappearing(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void UserLicenceButtonOnClicked(object sender, EventArgs e)
        {
            PDFPage userLicencePage = new PDFPage("Пользовательское соглашение", "https://luna-m.ru/pdf/userLicence.pdf");
            userLicencePage.Disappearing += AboutOnDisappearing;

            NavigationManager.PushPage(userLicencePage);
        }
    }
}
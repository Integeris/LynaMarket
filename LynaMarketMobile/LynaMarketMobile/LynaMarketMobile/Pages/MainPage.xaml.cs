using LunaMarketEngine;
using LunaMarketEngine.Entities;
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
        private readonly ObservableCollection<NewsView> news = new ObservableCollection<NewsView>();

        public MainPage()
        {
            InitializeComponent();

            NewsCarouselView.ItemsSource = news;
            LoadDataAsync();
        }

        private void LoadDataAsync()
        {
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                ListView listView = (ListView)new CatalogPage().Content.FindByName("CatalogListView");
                listView.ItemAppearing += ListViewOnItemAppearing;
                CatalogContentView.Content = listView;
            });

            List<NewsView> newNews = (await Core.GetNewsAsync()).AsParallel().Select(innerNews => new NewsView(innerNews)).ToList();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                NewsCarouselView.Position = 0;
                news.Clear();

                foreach (var item in newNews)
                {
                    news.Add(item);
                }
            });
        }

        private void ListViewOnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            ListView listView = (ListView)sender;
            CatalogContentView.HeightRequest = listView.RowHeight * (e.ItemIndex + 1);
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
            MainSearchBar.Text = null;
            LoadDataAsync();
        }

        private void AboutProgramButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new AboutProgramPage());
        }

        private void AboutCompanyButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new AboutCompanyPage());
        }
    }
}
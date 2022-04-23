using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private BindingList<NewsView> news;

        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            CatalogContentView.Content = new CatalogPage().Content;
            news = new BindingList<NewsView>((await Core.GetNewsAsync()).Select(innerNews => new NewsView(innerNews)).ToList());

            NewsCarouselView.ItemsSource = news;
        }

        private void NewsButtonOnClicked(object sender, EventArgs e)
        {
            NewsView newsView = (NewsView)NewsCarouselView.CurrentItem;
            NavigationManager.PushPage(new NewsPage(newsView.IdNews));
        }
    }
}
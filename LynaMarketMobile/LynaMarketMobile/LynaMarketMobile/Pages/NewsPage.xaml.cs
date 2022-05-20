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
    public partial class NewsPage : ContentPage
    {
        private News News { get; set; }

        public NewsPage(int idNews)
        {
            InitializeComponent();
            Task.Run(() => LoadData(idNews));
        }

        public async void LoadData(int idNews)
        {
            News = await Core.GetNewsAsync(idNews);

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                this.BindingContext = News;
                MainImage.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(News.Photo));
            });
        }

        protected override bool OnBackButtonPressed()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            return base.OnBackButtonPressed();
        }
    }
}
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
            LoadNews(idNews);
        }

        public async void LoadNews(int idNews)
        {
            News = await Core.GetNewsAsync(idNews);
            this.BindingContext = News;
            MainImage.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(News.Photo));
        }
    }
}
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

            Category[] categories = new string[] { "dasgfds", "dasgfds" }.Select(c => new Category() { Title = c }).ToArray();
            CatalogListView.ItemsSource = categories;
        }

        private void ListViewButtonOnClicked(object sender, EventArgs e)
        {
            NavigationManager.PushPage(new ProductsPage());
        }
    }
}
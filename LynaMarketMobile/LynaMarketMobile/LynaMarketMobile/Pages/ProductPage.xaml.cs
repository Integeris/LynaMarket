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
    public partial class ProductPage : ContentPage
    {
        private ProductView Product { get; set; }

        public ProductPage(int idProduct)
        {
            InitializeComponent();
            Task.Run(() => LoadData(idProduct));
        }

        private async void LoadData(int idProduct)
        {
            Product product = await Core.GetProductAsync(idProduct);
            Product = new ProductView()
            {
                IdProduct = product.IdProduct,
                Title = product.Title,
                Manufacturer = (await product.GetManufacturerAsync()).Title,
                MatrialTitle = (await product.GetMaterialAsync()).Title,
                ColorTitle = (await product.GetProductColorAsync()).Title,
                Price = product.Price,
                Amount = product.Amount,
                Width = product.Width,
                Height = product.Height,
                Depth = product.Depth,
                Description = product.Description
            };

            List<ProductPhoto> photos = await product.GetProductPhotoAsync();

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                UpdateAddButton();
                this.BindingContext = Product;
                MainImagePicker.Images = photos;
            });
        }

        private void AddButtonOnClicked(object sender, EventArgs e)
        {
            if (BasketManager.ProductIds.Contains(Product.IdProduct))
            {
                BasketManager.ProductIds.Remove(Product.IdProduct);
            }
            else
            {
                BasketManager.ProductIds.Add(Product.IdProduct);
            }
            
            UpdateAddButton();
        }

        private void UpdateAddButton()
        {
            if (BasketManager.ProductIds.Contains(Product.IdProduct))
            {
                AddButton.Text = "Товар уже в корзине.";
                AddButton.BackgroundColor = Xamarin.Forms.Color.DarkGray;
            }
            else
            {
                AddButton.Text = "Добавить в корзину";
                AddButton.BackgroundColor = Xamarin.Forms.Color.LightGray;
            }
        }
    }
}
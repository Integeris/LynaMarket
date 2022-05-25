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
                AddButton.IsEnabled = true;
            });
        }

        private async void AddButtonOnClicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            BasketProductView view = BasketManager.BasketProductViews.FirstOrDefault(product => product.IdProduct == Product.IdProduct);

            if (view != default)
            {
                BasketManager.BasketProductViews.Remove(view);
            }
            else
            {
                Product product = await Core.GetProductAsync(Product.IdProduct);

                view = new BasketProductView()
                {
                    IdProduct = product.IdProduct,
                    ProductPrice = product.Price,
                    Title = product.Title,
                    Image = (await product.GetProductPhotoAsync()).FirstOrDefault().Image,
                    Amount = 1,
                    MaxAmount = product.Amount
                };

                BasketManager.BasketProductViews.Add(view);
            }
            
            UpdateAddButton();
            AddButton.IsEnabled = true;
        }

        private void UpdateAddButton()
        {
            if (BasketManager.BasketProductViews.FirstOrDefault(product => product.IdProduct == Product.IdProduct) != default)
            {
                AddButton.Text = "Товар в корзине";
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
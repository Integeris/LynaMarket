using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using LynaMarketMobile.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = LunaMarketEngine.Entities.Color;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        private readonly Filter filter;

        private List<FilterView> productCategoriesViews;
        private List<FilterView> manufacturersViews;
        private List<FilterView> colorsViews;
        private List<FilterView> materialsViews;

        public FilterPage(Filter filter)
        {
            InitializeComponent();
            this.filter = filter;
            Task.Run(() => LoadData());
        }

        private async void LoadData()
        {
            List<ProductCategory> productCategories = await Core.GetProductCategoriesAsync();
            List<Manufacturer> manufacturers = await Core.GetManufacturersAsync();
            List<Color> colors = await Core.GetColorsAsync();
            List<Material> materials = await Core.GetMaterialsAsync();

            productCategoriesViews = productCategories.AsParallel().Select(category => new FilterView()
            {
                IdObject = category.IdProductCategory,
                Title = category.Title
            }).ToList();

            manufacturersViews = manufacturers.AsParallel().Select(manufacturer => new FilterView() 
            { 
                IdObject = manufacturer.IdManufacturer, 
                Title = manufacturer.Title
            }).ToList();

            colorsViews = colors.AsParallel().Select(color => new FilterView()
            {
                IdObject = color.IdColor,
                Title = color.Title
            }).ToList();

            materialsViews = materials.AsParallel().Select(material => new FilterView()
            {
                IdObject = material.IdMaterial,
                Title = material.Title
            }).ToList();

            if (filter.ProductCategories != null)
            {
                foreach (var category in filter.ProductCategories)
                {
                    productCategoriesViews.First(innerManufacturer => innerManufacturer.IdObject == category.IdProductCategory).IsEnabled = true;
                }
            }

            if (filter.Manufacturers != null)
            {
                foreach (var manufacturer in filter.Manufacturers)
                {
                    manufacturersViews.First(innerManufacturer => innerManufacturer.IdObject == manufacturer.IdManufacturer).IsEnabled = true;
                }
            }

            if (filter.Colors != null)
            {
                foreach (var color in filter.Colors)
                {
                    colorsViews.First(innerColor => innerColor.IdObject == color.IdColor).IsEnabled = true;
                }
            }

            if (filter.Materials != null)
            {
                foreach (var material in filter.Materials)
                {
                    materialsViews.First(innerMaterial => innerMaterial.IdObject == material.IdMaterial).IsEnabled = true;
                }
            }

            this.Dispatcher.BeginInvokeOnMainThread(() =>
            {
                ProductCategoriesListView.ItemsSource = productCategoriesViews;
                ManufactorersListView.ItemsSource = manufacturersViews;
                ColorsListView.ItemsSource = colorsViews;
                MaterialsListView.ItemsSource = materialsViews;

                SetIfNotNull(PricePropertyChanger, filter.FromPrice, filter.ToPrice);
                SetIfNotNull(WidthPropertyChanger, filter.FromWidth, filter.ToWidth);
                SetIfNotNull(HeightPropertyChanger, filter.FromHeight, filter.ToHeight);
                SetIfNotNull(DepthPropertyChanger, filter.FromDepth, filter.ToDepth);
            });
        }

        private void PropertyChangerOnCompleted(object sender, PropertyChangerEventArgs e)
        {
            PropertyChanger propertyChanger = (PropertyChanger)sender;

            if (String.IsNullOrEmpty(propertyChanger.FromValue) || String.IsNullOrEmpty(propertyChanger.ToValue))
            {
                return;
            }

            if (Decimal.Parse(propertyChanger.FromValue) > Decimal.Parse(propertyChanger.ToValue))
            {
                e.Entry.Text = "";
                InfoViewer.ShowError(this, "Начальное значение не может быть больше конечного значения.");
            }
        }

        private void ApplyButtonOnClicked(object sender, EventArgs e)
        {
            Task.Run(() => FilterUpdate());
        }

        private async void FilterUpdate()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            List<Color> colors = new List<Color>();
            List<Material> materials = new List<Material>();

            foreach (var item in productCategoriesViews.Where(category => category.IsEnabled == true))
            {
                productCategories.Add(await Core.GetProductCategoryAsync(item.IdObject));
            }

            foreach (var item in manufacturersViews.Where(manufacturer => manufacturer.IsEnabled == true))
            {
                manufacturers.Add(await Core.GetManufacturerAnsyc(item.IdObject));
            }

            foreach (var item in colorsViews.Where(color => color.IsEnabled == true))
            {
                colors.Add(await Core.GetColorAsync(item.IdObject));
            }

            foreach (var item in materialsViews.Where(material => material.IsEnabled == true))
            {
                materials.Add(await Core.GetMaterialAsync(item.IdObject));
            }

            filter.ProductCategories = productCategories.Count > 0 ? productCategories : null;
            filter.Manufacturers = manufacturers.Count > 0 ? manufacturers : null;
            filter.Colors = colors.Count > 0 ? colors : null;
            filter.Materials = materials.Count > 0 ? materials : null;

            SetFilterValue(nameof(filter.FromPrice), PricePropertyChanger.FromValue);
            SetFilterValue(nameof(filter.ToPrice), PricePropertyChanger.ToValue);

            SetFilterValue(nameof(filter.FromWidth), WidthPropertyChanger.FromValue);
            SetFilterValue(nameof(filter.ToWidth), WidthPropertyChanger.ToValue);

            SetFilterValue(nameof(filter.FromHeight), HeightPropertyChanger.FromValue);
            SetFilterValue(nameof(filter.ToHeight), HeightPropertyChanger.ToValue);

            SetFilterValue(nameof(filter.FromDepth), DepthPropertyChanger.FromValue);
            SetFilterValue(nameof(filter.ToDepth), DepthPropertyChanger.ToValue);

            this.Dispatcher.BeginInvokeOnMainThread(() => NavigationManager.PopPage());
        }

        private void SetFilterValue(string nameProperty, string value)
        {
            PropertyInfo propertyInfo = filter.GetType().GetProperty(nameProperty);

            if (String.IsNullOrWhiteSpace(value))
            {
                propertyInfo.SetValue(filter, default);
            }
            else
            {
                Type propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);

                MethodInfo method = propertyType.GetMethod("Parse", new Type[] {typeof(String)});
                propertyInfo.SetValue(filter, method.Invoke(default, new object[] { value }));
            }
        }

        private void SetIfNotNull(PropertyChanger propertyChanger, object fromValue, object toValue)
        {
            if (fromValue != null)
            {
                propertyChanger.FromValue = fromValue.ToString();
            }

            if (toValue != null)
            {
                propertyChanger.ToValue = toValue.ToString();
            }
        }
    }
}
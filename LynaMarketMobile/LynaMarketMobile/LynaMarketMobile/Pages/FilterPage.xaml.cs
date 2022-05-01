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

        private List<FilterView> manufacturersViews;
        private List<FilterView> colorsViews;
        private List<FilterView> materialsViews;

        public FilterPage(Filter filter)
        {
            InitializeComponent();
            this.filter = filter;
            LoadData();
        }

        private async void LoadData()
        {
            List<Manufacturer> manufacturers = await Core.GetManufacturersAsync();
            List<Color> colors = await Core.GetColorsAsync();
            List<Material> materials = await Core.GetMaterialsAsync();

            manufacturersViews = manufacturers.Select(manufacturer => new FilterView() 
            { 
                IdObject = manufacturer.IdManufacturer, 
                Title = manufacturer.Title
            }).ToList();

            colorsViews = colors.Select(color => new FilterView()
            {
                IdObject = color.IdColor,
                Title = color.Title
            }).ToList();

            materialsViews = materials.Select(material => new FilterView()
            {
                IdObject = material.IdMaterial,
                Title = material.Title
            }).ToList();

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

            ManufactorersListView.ItemsSource = manufacturersViews;
            ColorsListView.ItemsSource = colorsViews;
            MaterialsListView.ItemsSource = materialsViews;

            SetIfNotNull(PricePropertyChanger, filter.FromPrice, filter.ToPrice);
            SetIfNotNull(WidthPropertyChanger, filter.FromWidth, filter.ToWidth);
            SetIfNotNull(HeightPropertyChanger, filter.FromHeight, filter.ToHeight);
            SetIfNotNull(DepthPropertyChanger, filter.FromDepth, filter.ToDepth);
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

        private async void ApplyButtonOnClicked(object sender, EventArgs e)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            List<Color> colors = new List<Color>();
            List<Material> materials = new List<Material>();

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

            NavigationManager.PopPage();
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
using LunaMarketEngine;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
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
    public partial class SortingSettingsPage : ContentPage
    {
        private readonly Filter filter;

        private readonly List<SortingPropertyView> sortingPropertyViews = new List<SortingPropertyView>()
        {
            new SortingPropertyView() { Title = "По цене", Property = "Price"},
            new SortingPropertyView() { Title = "По названию", Property = "Title"},
            new SortingPropertyView() { Title = "По ширине", Property = "Width"},
            new SortingPropertyView() { Title = "По высоте", Property = "Height"},
            new SortingPropertyView() { Title = "По глубине", Property = "Depth"}
        };

        public SortingSettingsPage(Filter filter)
        {
            InitializeComponent();

            this.filter = filter;
            List<SortingProperty> sortings = filter.SortingProperties;

            if (sortings != null)
            {
                for (int i = 0; i < sortings.Count; i++)
                {
                    SortingProperty sortingProperty = sortings[i];
                    SortingPropertyView sortingPropertyView = sortingPropertyViews.First(property => property.Property == sortingProperty.ColumnName);
                    sortingPropertyView.IsEnabled = true;
                    sortingPropertyView.IsASC = sortingProperty.IsASC;

                    sortingPropertyViews.Remove(sortingPropertyView);
                    sortingPropertyViews.Insert(i, sortingPropertyView);
                }
            }

            LoadData();
        }

        private void LoadData()
        {
            PropertyListView.ItemsSource = null;
            PropertyListView.ItemsSource = sortingPropertyViews;
        }

        private void ApplyButtonOnClicked(object sender, EventArgs e)
        {
            List<SortingPropertyView> selectedProperties = sortingPropertyViews.Where(property => property.IsEnabled == true).ToList();

            if (selectedProperties.Count == 0)
            {
                filter.SortingProperties = null;
            }
            else
            {
                filter.SortingProperties = new List<SortingProperty>();

                foreach (var item in selectedProperties)
                {
                    filter.SortingProperties.Add(new SortingProperty(item.Property, item.IsASC));
                }
            }

            NavigationManager.PopPage();
        }

        private void PropertyListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SortingPropertyView selectedProperty = (SortingPropertyView)PropertyListView.SelectedItem;
            int index = sortingPropertyViews.IndexOf(selectedProperty);

            if (index == 0)
            {
                UpButton.IsEnabled = false;
                DownButton.IsEnabled = true;
            }
            else if (index == sortingPropertyViews.Count - 1)
            {
                UpButton.IsEnabled = true;
                DownButton.IsEnabled = false;
            }
            else
            {
                UpButton.IsEnabled = true;
                DownButton.IsEnabled = true;
            }
        }

        private void UpButtonOnClicked(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void DownButtonOnClicked(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void MoveItem(int offset)
        {
            SortingPropertyView selectedItem = (SortingPropertyView)PropertyListView.SelectedItem;

            try
            {
                if (selectedItem == null)
                {
                    throw new Exception("Выделите хотябы одно свойство.");
                }

                int index = sortingPropertyViews.IndexOf(selectedItem);

                sortingPropertyViews.RemoveAt(index);
                index += offset;
                sortingPropertyViews.Insert(index, selectedItem);

                LoadData();

                PropertyListView.SelectedItem = null;
                PropertyListView.SelectedItem = sortingPropertyViews[index];
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(this, ex.Message);
            }
        }
    }
}
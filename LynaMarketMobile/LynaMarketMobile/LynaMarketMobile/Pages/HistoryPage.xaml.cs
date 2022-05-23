using LunaMarketEngine;
using LunaMarketEngine.Entities;
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
	public partial class HistoryPage : ContentPage
	{
		private const int itemsOnPage = 20;

		public HistoryPage ()
		{
			InitializeComponent();

			MainNavigator.ItemsCountOnPage = itemsOnPage;
			LoadDataAsync();
		}

		private void LoadDataAsync()
        {
			Task.Run(LoadData);
        }

		private async void LoadData()
        {
			this.Dispatcher.BeginInvokeOnMainThread(() =>
			{
				MainNavigator.IsEnabled = false;
				OrdersListView.BeginRefresh();
				OrdersListView.ItemsSource = null;
			});

			List<StaticProperty> staticProperties = new List<StaticProperty>()
			{
				new StaticProperty("IdCustomer", CurrentCustomer.IdCustomer)
			};

			List<SortingProperty> sortingProperties = new List<SortingProperty>()
			{
				new SortingProperty("IdOrder", false)
			};

			int navigatorPage = MainNavigator.CurrentPage;
			int itemsCount = (int)await Core.GetOrdersCountAsync(staticProperties);

			this.Dispatcher.BeginInvokeOnMainThread(() =>
			{
				MainNavigator.ItemsCount = itemsCount;
			});

			int pageCount = (int)Math.Ceiling((double)itemsCount / itemsOnPage);

			if (pageCount == 0)
			{
				pageCount++;
			}

			int skip = ((navigatorPage < pageCount ? navigatorPage : pageCount) - 1) * itemsOnPage;
			List<Order> orders = await Core.GetOrdersAsync(staticProperties, sortingProperties, skip, itemsOnPage);

			if (orders.Count == 0)
			{
				await Task.Delay(100);
				EmptySearchLabel.Opacity = 1;
			}
			else
			{
				EmptySearchLabel.Opacity = 0;
			}

			this.Dispatcher.BeginInvokeOnMainThread(() =>
			{
				OrdersListView.ItemsSource = orders;
			});

			this.Dispatcher.BeginInvokeOnMainThread(() =>
			{
				OrdersListView.EndRefresh();
				MainNavigator.IsEnabled = true;
			});
		}

        private void MainNavigatorOnSelectPage(object sender, SelectPageEventArgs e)
        {
			LoadDataAsync();
        }

		protected override bool OnBackButtonPressed()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			return base.OnBackButtonPressed();
		}

        private void ViewCellOnTapped(object sender, EventArgs e)
        {
			Order order = (Order)((ViewCell)sender).BindingContext;
			OrderPage orderPage = new OrderPage(order.IdOrder);
            orderPage.Disappearing += OrderPageOnDisappearing;
			NavigationManager.PushPage(orderPage);
        }

        private void OrderPageOnDisappearing(object sender, EventArgs e)
        {
			LoadDataAsync();
        }
    }
}
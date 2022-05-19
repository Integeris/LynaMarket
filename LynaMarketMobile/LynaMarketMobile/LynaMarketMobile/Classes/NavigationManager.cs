using LynaMarketMobile.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Менеджер навигации.
    /// </summary>
    internal static class NavigationManager
    {
        /// <summary>
        /// Нивигация.
        /// </summary>
        public static INavigation Navigation { get; set; }

        /// <summary>
        /// Открытие страницы.
        /// </summary>
        /// <param name="page">Страница.</param>
        public static async void PushPage(Page page)
        {
            await Navigation.PushAsync(page, false);
        }

        /// <summary>
        /// Закрытие страницы.
        /// </summary>
        public static async void PopPage()
        {
            await Navigation.PopAsync(false);
        }
    }
}

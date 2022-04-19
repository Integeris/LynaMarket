using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Помошник для вывода сообщений.
    /// </summary>
    internal static class InfoViewer
    {
        /// <summary>
        /// Вывод информации.
        /// </summary>
        /// <param name="page">Страница.</param>
        /// <param name="text">Текст.</param>
        public static void ShowInfo(Page page, string text)
        {
            page.DisplayAlert("Информация", text, "OK");
        }

        /// <summary>
        /// Вывод ошибки.
        /// </summary>
        /// <param name="page">Страница.</param>
        /// <param name="text">Текст.</param>
        public static void ShowError(Page page, string text)
        {
            page.DisplayAlert("Ошибка", text, "OK");
        }
    }
}

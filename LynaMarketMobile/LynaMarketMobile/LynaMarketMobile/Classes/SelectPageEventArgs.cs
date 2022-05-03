using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Аргументы события выбора страницы.
    /// </summary>
    public class SelectPageEventArgs : EventArgs
    {
        /// <summary>
        /// Выбранная страница.
        /// </summary>
        public int SelectedPage { get; private set; }

        /// <summary>
        /// Создание аргументов события выбора страницы.
        /// </summary>
        /// <param name="selectedPage">Выбранная страница.</param>
        public SelectPageEventArgs(int selectedPage)
        {
            this.SelectedPage = selectedPage;
        }
    }
}

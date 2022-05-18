using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Управление корзиной.
    /// </summary>
    internal class BasketManager
    {
        /// <summary>
        /// Идентификаторы продуктов в корзине.
        /// </summary>
        private static readonly ObservableCollection<BasketProductView> basketProductViews = new ObservableCollection<BasketProductView>();

        /// <summary>
        /// Идентификаторы продуктов в корзине.
        /// </summary>
        public static ObservableCollection<BasketProductView> BasketProductViews
        {
            get => basketProductViews;
        }
    }
}

using System.Collections.Generic;

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
        private static readonly List<int> productIds = new List<int>();

        /// <summary>
        /// Идентификаторы продуктов в корзине.
        /// </summary>
        public static List<int> ProductIds
        {
            get => productIds;
        }
    }
}

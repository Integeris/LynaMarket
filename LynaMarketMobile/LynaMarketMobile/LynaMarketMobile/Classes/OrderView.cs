using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Внешний вид заказа.
    /// </summary>
    internal class OrderView
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int IdOrder { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// Тип доставки.
        /// </summary>
        public string DeliveryType { get; set; }

        /// <summary>
        /// Адресс.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Полная цена.
        /// </summary>
        public decimal Price { get; set; }
    }
}

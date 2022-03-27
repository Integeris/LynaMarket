using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Состав заказа.
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public int IdOrder { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public Order Order
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdOrder"] = IdOrder.ToString()
                };

                return Core.GetObjectAsync<Order>(properties).Result;
            }
        }

        /// <summary>
        /// Товар.
        /// </summary>
        public Product Product
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdProduct"] = IdProduct.ToString()
                };

                return Core.GetObjectAsync<Product>(properties).Result;
            }
        }
    }
}

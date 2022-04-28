using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using MySqlConnector;
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
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdOrder", IdOrder)
                };

                return Core.GetObjectAsync<Order>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Товар.
        /// </summary>
        public Product Product
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdProduct", IdProduct)
                };

                return Core.GetObjectAsync<Product>(staticProperties).Result;
            }
        }
    }
}

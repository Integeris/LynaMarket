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
        public async Task<Order> GetOrderAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", IdOrder)
            };

            return await Core.GetObjectAsync<Order>(staticProperties);
        }

        /// <summary>
        /// Товар.
        /// </summary>
        public async Task<Product> GetProductAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", IdProduct)
            };

            return await Core.GetObjectAsync<Product>(staticProperties);
        }
    }
}

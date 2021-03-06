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
    /// Статус заказа.
    /// </summary>
    public class OrderStatus
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdOrderStatus { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение заказов статуса заказов.
        /// </summary>
        /// <returns>Заказы статуса заказов.</returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", IdOrderStatus)
            };

            return await Core.GetObjectsListAsync<Order>(staticProperties);
        }
    }
}

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
    /// Тип доставки.
    /// </summary>
    public class DeliveryType
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdDeliveryType { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение продуктов заказа.
        /// </summary>
        /// <returns>Продукты заказа.</returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", IdDeliveryType)
            };

            return await Core.GetObjectsListAsync<Order>(staticProperties);
        }
    }
}

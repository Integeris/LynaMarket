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
        /// Продукты заказа.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdDeliveryType"] = (MySqlDbType.Int32, IdDeliveryType)
                };

                return Core.GetObjectsListAsync<Order>(properties).Result;
            }
        }
    }
}

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
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdDeliveryType"] = IdDeliveryType.ToString()
                };

                return Core.GetObjectsListAsync<Order>(properties).Result;
            }
        }
    }
}

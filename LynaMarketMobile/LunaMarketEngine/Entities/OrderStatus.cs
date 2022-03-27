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
        /// Продукты заказа.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdOrderStatus"] = IdOrderStatus.ToString()
                };

                return Core.GetObjectsListAsync<Order>(properties).Result;
            }
        }
    }
}

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
    }
}

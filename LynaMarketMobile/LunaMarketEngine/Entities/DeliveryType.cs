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
    }
}

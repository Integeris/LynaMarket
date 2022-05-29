using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Статус оплаты.
    /// </summary>
    public class PayStatus
    {
        /// <summary>
        /// Идентификатор статуса оплаты.
        /// </summary>
        public int IdPayStatus { get; set; }

        /// <summary>
        /// Название статуса оплаты.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение списка заказов с данным статусом оплаты.
        /// </summary>
        /// <returns>Список заказов.</returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPayStatus", IdPayStatus)
            };

            return await Core.GetObjectsListAsync<Order>(staticProperties);
        }
    }
}

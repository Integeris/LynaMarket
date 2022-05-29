using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Способ оплаты.
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// Идентификатор способа оплаты.
        /// </summary>
        public int IdPaymentMethod { get; set; }

        /// <summary>
        /// Название способа оплаты.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение списка заказов с данным способом оплаты.
        /// </summary>
        /// <returns>Список заказов.</returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPaymentMethod", IdPaymentMethod)
            };

            return await Core.GetObjectsListAsync<Order>(staticProperties);
        }
    }
}

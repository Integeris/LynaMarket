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
    /// Заказ.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdOrder { get; set; }

        /// <summary>
        /// Идентификатор заказчика.
        /// </summary>
        public int IdCustomer { get; set; }

        /// <summary>
        /// Идентификатор статуса заказа.
        /// </summary>
        public int IdOrderStatus { get; set; }

        /// <summary>
        /// Идентификатор типа доставки.
        /// </summary>
        public int IdDeliveryType { get; set; }

        /// <summary>
        /// Время.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Адресс.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        public async Task<OrderStatus> GetOrderStatusAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", IdOrderStatus)
            };

            return await Core.GetObjectAsync<OrderStatus>(staticProperties);
        }
        
        /// <summary>
        /// Заказчик.
        /// </summary>
        public async Task<Customer> GetCustomerAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", IdCustomer)
            };

            return await Core.GetObjectAsync<Customer>(staticProperties);
        }

        /// <summary>
        /// Тип заказа.
        /// </summary>
        public async Task<DeliveryType> GetDeliveryTypeAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", IdDeliveryType)
            };

            return await Core.GetObjectAsync<DeliveryType>(staticProperties);
        }

        /// <summary>
        /// Продукты заказа.
        /// </summary>
        public async Task<List<OrderProduct>> GetOrderProductsAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", IdOrder)
            };

            return await Core.GetObjectsListAsync<OrderProduct>(staticProperties);
        }
    }
}

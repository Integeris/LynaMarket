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
        /// Идентификатор способа оплаты.
        /// </summary>
        public int IdPaymentMethod { get; set; }

        /// <summary>
        /// Идентификатор статуса оплаты.
        /// </summary>
        public int IdPayStatus { get; set; }

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
        public string Address { get; set; }

        /// <summary>
        /// Получение статусаа заказа.
        /// </summary>
        /// <returns>Статус заказа.</returns>
        public async Task<OrderStatus> GetOrderStatusAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", IdOrderStatus)
            };

            return await Core.GetObjectAsync<OrderStatus>(staticProperties);
        }

        /// <summary>
        /// Получение заказчика.
        /// </summary>
        /// <returns>Заказчик.</returns>
        public async Task<Customer> GetCustomerAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", IdCustomer)
            };

            return await Core.GetObjectAsync<Customer>(staticProperties);
        }

        /// <summary>
        /// Получение статуса оплаты.
        /// </summary>
        /// <returns>Статус оплаты.</returns>
        public async Task<PayStatus> GetPayStatus()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPayStatus", IdPayStatus)
            };

            return await Core.GetObjectAsync<PayStatus>(staticProperties);
        }

        /// <summary>
        /// Получение способа оплаты.
        /// </summary>
        /// <returns>Способ оплаты.</returns>
        public async Task<PaymentMethod> GetPaymentMethod()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPaymentMethod", IdPaymentMethod)
            };

            return await Core.GetObjectAsync<PaymentMethod>(staticProperties);
        }

        /// <summary>
        /// Получение типа заказа.
        /// </summary>
        /// <returns>Тип заказа.</returns>
        public async Task<DeliveryType> GetDeliveryTypeAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", IdDeliveryType)
            };

            return await Core.GetObjectAsync<DeliveryType>(staticProperties);
        }

        /// <summary>
        /// Получение продуктов заказа.
        /// </summary>
        /// <returns>Продукты заказа.</returns>
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

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
        public OrderStatus OrderStatus
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdOrderStatus", IdOrderStatus)
                };

                return Core.GetObjectAsync<OrderStatus>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Заказчик.
        /// </summary>
        public Customer Customer
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdCustomer", IdCustomer)
                };

                return Core.GetObjectAsync<Customer>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Тип заказа.
        /// </summary>
        public DeliveryType DeliveryType
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdDeliveryType", IdDeliveryType)
                };

                return Core.GetObjectAsync<DeliveryType>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Продукты заказа.
        /// </summary>
        public List<OrderProduct> OrderProducts
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdOrder", IdOrder)
                };

                return Core.GetObjectsListAsync<OrderProduct>(staticProperties).Result;
            }
        }
    }
}

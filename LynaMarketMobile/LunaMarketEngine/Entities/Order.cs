﻿using System;
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
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdOrderStatus"] = IdOrderStatus.ToString()
                };

                return Core.GetObjectAsync<OrderStatus>(properties).Result;
            }
        }

        /// <summary>
        /// Заказчик.
        /// </summary>
        public Customer Customer
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdCustomer"] = IdCustomer.ToString()
                };

                return Core.GetObjectAsync<Customer>(properties).Result;
            }
        }

        /// <summary>
        /// Тип заказа.
        /// </summary>
        public DeliveryType DeliveryType
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdDeliveryType"] = IdDeliveryType.ToString()
                };

                return Core.GetObjectAsync<DeliveryType>(properties).Result;
            }
        }

        /// <summary>
        /// Продукты заказа.
        /// </summary>
        public List<OrderProduct> OrderProducts
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdOrder"] = IdOrder.ToString()
                };

                return Core.GetObjectsListAsync<OrderProduct>(properties).Result;
            }
        }
    }
}

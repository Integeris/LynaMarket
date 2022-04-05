using LunaMarketEngine;
using LunaMarketEngine.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Текущий покупатель.
    /// </summary>
    internal static class CurrentCustomer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public static int IdCustomer { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public static string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public static string Password { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public static string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public static string SecondName { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public static string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public static string Phone { get; set; }

        /// <summary>
        /// Заказы.
        /// </summary>
        public static List<Order> Orders
        {
            get
            {
                Customer customer = Core.GetCustomerAsync(IdCustomer).Result;
                return customer.Orders;
            }
        }
    }
}

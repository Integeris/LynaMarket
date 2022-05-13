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
    /// Заказчик.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdCustomer { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Получение заказов.
        /// </summary>
        /// <returns>Заказы.</returns>
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdCustomer", IdCustomer)
                };

            return await Core.GetObjectsListAsync<Order>(staticProperties);
        }
    }
}
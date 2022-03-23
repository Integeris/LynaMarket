using LunaMarketEngine.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine
{
    /// <summary>
    /// Обеспечение работы с базой данных.
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// Сервер.
        /// </summary>
        private static readonly string server = "nikt20hr.beget.tech";

        /// <summary>
        /// База данных.
        /// </summary>
        private static readonly string database = "nikt20hr_mainbd";

        /// <summary>
        /// Пользователь.
        /// </summary>
        private static readonly string user = "nikt20hr_mainbd";

        /// <summary>
        /// Пароль.
        /// </summary>
        private static readonly string password  = "Nikt2001";

        /// <summary>
        /// Подключение.
        /// </summary>
        private static readonly MySqlConnection connection = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server = server,
                Database = database,
                UserID = user,
                Password = password
            }.ConnectionString);

        /// <summary>
        /// SQL-команда.
        /// </summary>
        private static readonly MySqlCommand command = new MySqlCommand()
        {
            Connection = connection
        };

        /// <summary>
        /// Сервер.
        /// </summary>
        internal static string Server
        {
            get => server;
        }

        /// <summary>
        /// База данных.
        /// </summary>
        internal static string Database
        {
            get => server;
        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        internal static string User
        {
            get => server;
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        internal static string Password
        {
            get => server;
        }

        /// <summary>
        /// Открытие подключения к базе данных.
        /// </summary>
        /// <exception cref="Exception">Ошибка подключения к базе данных.</exception>
        private static void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось подключится к базе данных.", ex);
            }
        }

        /// <summary>
        /// Закрытие подключения к базе данных.
        /// </summary>
        /// <exception cref="Exception">Ошибка отключения от базы данных.</exception>
        private static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось закрыть подключение к базе данных.", ex);
                throw;
            }
        }

        /// <summary>
        /// Получение списка категорий товаров.
        /// </summary>
        /// <returns>Список категорий товаров.</returns>
        public static async Task<List<ProductCategory>> GetCategoryProducts()
        {
            List<ProductCategory> categories = new List<ProductCategory>();
            command.CommandText = "SELECT * FROM ProductCategory;";

            OpenConnection();

            MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                ProductCategory category = new ProductCategory
                {
                    IdProductCategory = reader.GetInt32("IdProductCategory"),
                    Title = reader.GetString("Title")
                };

                categories.Add(category);
            }

            CloseConnection();

            return categories;
        }

        /// <summary>
        /// Добавление категории товара.
        /// </summary>
        /// <param name="title">Наименование категории товара.</param>
        public static async void AddCategoryProducts(string title)
        {
            command.CommandText = $"ProductCategory (Title) VALUES ({title});";
            OpenConnection();
            await command.ExecuteNonQueryAsync();
            CloseConnection();
        }

        /// <summary>
        /// Изменение названия категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="title">Новое название категории товара.</param>
        public static async void UpdateCategoryProducts(int idProductCategory, string title)
        {
            command.CommandText = $"UPDATE ProductCategory SET Title = '{title}' WHERE (IdProductCategory = '{idProductCategory}');";
            OpenConnection();
            await command.ExecuteNonQueryAsync();
            CloseConnection();
        }

        /// <summary>
        /// Удаление категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        public static async void DeleteCategoryProducts(int idProductCategory)
        {
            command.CommandText = $"DELETE FROM ProductCategory WHERE (IdProductCategory = '{idProductCategory}');";
            OpenConnection();
            await command.ExecuteNonQueryAsync();
            CloseConnection();
        }
    }
}
using LunaMarketEngine.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static string Server
        {
            get => server;
        }

        /// <summary>
        /// База данных.
        /// </summary>
        public static string Database
        {
            get => server;
        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public static string User
        {
            get => server;
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public static string Password
        {
            get => server;
        }

        /// <summary>
        /// Получение списка категорий товаров.
        /// </summary>
        /// <returns>Список категорий товаров.</returns>
        public static async Task<List<ProductCategory>> GetCategoryProducts()
        {
            return await GetObjectsListAsync<ProductCategory>();
        }

        /// <summary>
        /// Добавление категории товара.
        /// </summary>
        /// <param name="title">Наименование категории товара.</param>
        public static void AddCategoryProducts(string title)
        {
            ProductCategory productCategory = new ProductCategory
            {
                Title = title
            };

            ExecuteCommand(productCategory);
        }

        /// <summary>
        /// Изменение названия категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="title">Новое название категории товара.</param>
        public static void UpdateCategoryProducts(int idProductCategory, string title)
        {
            ProductCategory productCategory = new ProductCategory
            {
                Title = title
            };

            ExecuteCommand(idProductCategory, "IdProductCategory", productCategory);
        }

        /// <summary>
        /// Удаление категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        public static void DeleteCategoryProduct(int idProductCategory)
        {
            ExecuteCommand("CategoryProduct", idProductCategory, "IdCategoryProduct");
        }

        /// <summary>
        /// Получение списка цветов.
        /// </summary>
        /// <returns>Список цветов.</returns>
        public static async Task<List<Color>> GetColors()
        {
            return await GetObjectsListAsync<Color>();
        }

        /// <summary>
        /// Добавление цвета.
        /// </summary>
        /// <param name="title">Название цвета.</param>
        public static void AddColor(string title)
        {
            Color color = new Color
            {
                Title = title
            };

            ExecuteCommand(color);
        }

        /// <summary>
        /// Изменение цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="title">Новое название цвета.</param>
        public static void UpdateColor(int idColor, string title)
        {
            Color color = new Color
            {
                Title = title
            };

            ExecuteCommand(idColor, "IdColor", color);
        }

        /// <summary>
        /// Удаление  цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        public static void DeleteColor(int idColor)
        {
            ExecuteCommand("Color", idColor, "IdColor");
        }

        /// <summary>
        /// Получение списка видов доставки.
        /// </summary>
        /// <returns>Список видов доставки.</returns>
        public static async Task<List<DeliveryType>> GetDeliveryTypes()
        {
            return await GetObjectsListAsync<DeliveryType>();
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
            }
        }

        /// <summary>
        /// Получение списка объектов типа.
        /// </summary>
        /// <typeparam name="T">Тип элемента получаемых данных.</typeparam>
        /// <returns>Список объектов типа.</returns>
        private static async Task<List<T>> GetObjectsListAsync<T>()
        {
            Type type = typeof(T);
            List<T> objectList = new List<T>();
            command.CommandText = $"SELECT * FROM {type.Name};";
            PropertyInfo[] properties = type.GetProperties();

            OpenConnection();
            MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                T obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

                foreach (PropertyInfo property in properties)
                {
                    property.SetValue(obj, reader.GetValue(reader.GetOrdinal(property.Name)));
                }

                objectList.Add(obj);
            }

            reader.Close();
            CloseConnection();

            return objectList;
        }

        /// <summary>
        /// Получение названий свойств и значений свойств за исключением идентификатора.
        /// </summary>
        /// <typeparam name="T">Тип объекта получения данных.</typeparam>
        /// <param name="obj">Объект получения данных.</param>
        /// <returns>Списки имён свойств и значения свойств.</returns>
        private static (List<string> Names, List<string> Values) GetPropertiesValues<T>(T obj)
        {
            (List<string> Names, List<string> Values) data = (new List<string>(), new List<string>());

            PropertyInfo[] properties = typeof(T).GetProperties()
                .Where(property => !System.Text.RegularExpressions.Regex.IsMatch(property.Name, @"^Id[A-Z][A-Za-z\d]*$"))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                data.Names.Add(property.Name);
                data.Values.Add(property.GetValue(obj).ToString());
            }

            return data;
        }

        /// <summary>
        /// Добавление объекта.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="obj">Объект.</param>
        private static void ExecuteCommand<T>(T obj)
        {
            (List<string> Names, List<string> Values) = GetPropertiesValues(obj);

            command.CommandText = $"INSERT INTO '{typeof(T).Name}' ({String.Join(", ", Names)}) VALUES ({String.Join(", ", Values)});";
            SendDataAsync();
        }

        /// <summary>
        /// Изменение объекта.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="idObject">Идентификатор объекта.</param>
        /// <param name="idPropertyName">Название свойства идентификатора объекта.</param>
        /// <param name="obj">Объект.</param>
        private static void ExecuteCommand<T>(int idObject, string idPropertyName, T obj)
        {
            (List<string> Names, List<string> Values) = GetPropertiesValues(obj);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"UPDATE {typeof(T).Name} SET");
            List<string> parameters = new List<string>();

            for (int i = 0; i < Names.Count; i++)
            {
                parameters.Add($"{Names[i]} = {Values[i]}");
            }

            stringBuilder.AppendLine(String.Join(", ", parameters));
            stringBuilder.AppendLine($"WHERE ({idPropertyName} = '{idObject}');");
            SendDataAsync();
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="table">Название таблицы.</param>
        /// <param name="idObject">Идентификатор объекта.</param>
        /// <param name="idPropertyName">Название идентификатора объекта.</param>
        private static void ExecuteCommand(string table, int idObject, string idPropertyName)
        {
            command.CommandText = $"DELETE FROM {table} WHERE({idPropertyName} = '{idObject}');";
            SendDataAsync();
        }

        /// <summary>
        /// Отправка данных команды.
        /// </summary>
        private static async void SendDataAsync()
        {
            OpenConnection();
            await command.ExecuteNonQueryAsync();
            CloseConnection();
        }
    }
}
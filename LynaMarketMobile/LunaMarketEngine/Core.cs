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
        public static async Task<List<ProductCategory>> GetProductCategories()
        {

            return await GetObjectsListAsync<ProductCategory>();
        }

        /// <summary>
        /// Получение категории товаров.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <returns>Категория товаров.</returns>
        public static async Task<ProductCategory> GetProductCategory(int idProductCategory)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProductCategory"] = idProductCategory.ToString()
            };

            return await GetObjectAsync<ProductCategory>(properties);
        }

        /// <summary>
        /// Добавление категории товара.
        /// </summary>
        /// <param name="title">Наименование категории товара.</param>
        public static void AddProductCategory(string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            AddObject("CategoryProduct", properties);
        }

        /// <summary>
        /// Изменение названия категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="title">Новое название категории товара.</param>
        public static void UpdateProductCategory(int idProductCategory, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProductCategory"] = idProductCategory.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("CategoryProduct", properties, newProperties);
        }

        /// <summary>
        /// Удаление категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        public static void DeleteProductCategory(int idProductCategory)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProductCategory"] = idProductCategory.ToString()
            };

            DeleteObject("ProductCategory", properties);
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
        /// Получение цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <returns>Цвет.</returns>
        public static async Task<Color> GetColor(int idColor)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdColor"] = idColor.ToString()
            };

            return await GetObjectAsync<Color>(properties);
        }

        /// <summary>
        /// Добавление цвета.
        /// </summary>
        /// <param name="title">Название цвета.</param>
        public static void AddColor(string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            AddObject("Color", properties);
        }

        /// <summary>
        /// Изменение цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="title">Новое название цвета.</param>
        public static void UpdateColor(int idColor, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdColor"] = idColor.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("Color", properties, newProperties);
        }

        /// <summary>
        /// Удаление  цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        public static void DeleteColor(int idColor)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdColor"] = idColor.ToString()
            };

            DeleteObject("Color", properties);
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
        /// Получение типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        /// <returns>Тип доставки.</returns>
        public static async Task<DeliveryType> GetDeliveryType(int idDeliveryType)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdDeliveryType"] = idDeliveryType.ToString()
            };

            return await GetObjectAsync<DeliveryType>(properties);
        }

        /// <summary>
        /// Добавление типа доставки.
        /// </summary>
        /// <param name="title">Название типа доставки.</param>
        public static void AddDeliveryType(string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            AddObject("DeliveryType", properties);
        }

        /// <summary>
        /// Изменение типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        /// <param name="title">Название типа доставки.</param>
        public static void UpdateDeliveryType(int idDeliveryType, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdDeliveryType"] = idDeliveryType.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("DeliveryType", properties, newProperties);
        }

        /// <summary>
        /// Удаление типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        public static void DeleteDeliveryType(int idDeliveryType)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdDeliveryType"] = idDeliveryType.ToString()
            };

            DeleteObject("DeliveryType", properties);
        }

        /// <summary>
        /// Получение списка материалов.
        /// </summary>
        /// <returns>Список материалов.</returns>
        public static async Task<List<Material>> GetMaterials()
        {
            return await GetObjectsListAsync<Material>();
        }

        /// <summary>
        /// Получение материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <returns>Материал.</returns>
        public static async Task<Material> GetMaterial(int idMaterial)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdMaterial"] = idMaterial.ToString()
            };

            return await GetObjectAsync<Material>(properties);
        }

        /// <summary>
        /// Добавление материала.
        /// </summary>
        /// <param name="title">Название материала.</param>
        public static void AddMaterial(string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            AddObject("Material", properties);
        }

        /// <summary>
        /// Изменение материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="title">Название материала.</param>
        public static void UpdateMaterial(int idMaterial, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdMaterial"] = idMaterial.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("Material", properties, newProperties);
        }

        /// <summary>
        /// Удаление материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        public static void DeleteMaterial(int idMaterial)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdMaterial"] = idMaterial.ToString()
            };

            DeleteObject("Material", properties);
        }

        /// <summary>
        /// Получение списка новостей.
        /// </summary>
        /// <returns>Список новостей.</returns>
        public static async Task<List<News>> GetNews()
        {
            return await GetObjectsListAsync<News>();
        }

        /// <summary>
        /// Получение новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        /// <returns>Новось.</returns>
        public static async Task<News> GetNews(int idNews)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdNews"] = idNews.ToString()
            };

            return await GetObjectAsync<News>(properties);
        }

        /// <summary>
        /// Добавление новости.
        /// </summary>
        /// <param name="title">Заголовок новости.</param>
        /// <param name="date">Дата публикации новости.</param>
        /// <param name="photo">Изображение новости.</param>
        /// <param name="description">Описание новости.</param>
        public static void AddNews(string title, DateTime date, byte[] photo, string description)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["Title"] = title,
                ["Date"] = date.ToShortDateString(),
                ["Photo"] = String.Concat(photo.Select(data => data.ToString())),
                ["Description"] = description
            };

            AddObject("Material", properties);
        }

        /// <summary>
        /// Изменение новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        /// <param name="title">Заголовок новости.</param>
        /// <param name="date">Дата публикации новости.</param>
        /// <param name="photo">Изображение новости.</param>
        /// <param name="description">Описание новости.</param>
        public static void UpdateNews(int idNews, string title, DateTime date, byte[] photo, string description)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdNews"] = idNews.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title,
                ["Date"] = date.ToShortDateString(),
                ["Photo"] = String.Concat(photo.Select(data => data.ToString())),
                ["Description"] = description
            };

            UpdateObject("News", properties, newProperties);
        }

        /// <summary>
        /// Удаление новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        public static void DeleteNews(int idNews)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdNews"] = idNews.ToString()
            };

            DeleteObject("News", properties);
        }

        /// <summary>
        /// Получение информации о продуктах.
        /// </summary>
        /// <returns>Список информации о продуктах.</returns>
        public static async Task<List<ProductInfo>> GetProductInfosAsync()
        {
            return await GetObjectsListAsync<ProductInfo>();
        }

        /// <summary>
        /// Получение информации о товаре.
        /// </summary>
        /// <param name="idProduct">Идентификатор продукта.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <returns>Информация о товаре.</returns>
        public static async Task<ProductInfo> GetProductInfo(int idProduct, int idColor, int idMaterial)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString(),
                ["IdColor"] = idColor.ToString(),
                ["IdMaterial"] = idMaterial.ToString(),
            };

            return await GetObjectAsync<ProductInfo>(properties);
        }

        /// <summary>
        /// Добавление информации о товаре.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        public static void AddProductInfo(int idProduct, int idColor, int idMaterial, decimal price, int amount)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString(),
                ["IdColor"] = idColor.ToString(),
                ["IdMaterial"] = idMaterial.ToString(),
                ["Price"] = price.ToString(),
                ["Amount"] = amount.ToString()
            };

            AddObject("ProductInfo", properties);
        }

        /// <summary>
        /// Обновление информации о товаре.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="newIdProduct">Новый идентификатор продукта.</param>
        /// <param name="newIdColor">Новый идентификатор цвета.</param>
        /// <param name="newIdMaterial">Новый идентификатор материала.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        public static void UpdateProductInfo(int idProduct, int idColor, int idMaterial, int newIdProduct, int newIdColor, int newIdMaterial, decimal price, int amount)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString(),
                ["IdColor"] = idColor.ToString(),
                ["IdMaterial"] = idMaterial.ToString(),
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["IdProduct"] = newIdProduct.ToString(),
                ["IdColor"] = newIdColor.ToString(),
                ["IdMaterial"] = newIdMaterial.ToString(),
                ["Price"] = price.ToString(),
                ["Amount"] = amount.ToString()
            };

            UpdateObject("News", properties, newProperties);
        }

        /// <summary>
        /// Удаление информации о товаре.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        public static void DeleteProductInfo(int idProduct, int idColor, int idMaterial)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString(),
                ["IdColor"] = idColor.ToString(),
                ["IdMaterial"] = idMaterial.ToString(),
            };

            DeleteObject("ProductInfo", properties);
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

            OpenConnection();
            MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                T obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo property = type.GetProperty(reader.GetName(i));
                    property.SetValue(obj, reader.GetValue(i));
                }

                objectList.Add(obj);
            }

            reader.Close();
            CloseConnection();

            return objectList;
        }

        /// <summary>
        /// Получение объекта по идентификатору.
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта.</typeparam>
        /// <param name="properties">Свойства для поиска объекта.</param>
        /// <returns>Полученный объект.</returns>
        private static async Task<T> GetObjectAsync<T>(Dictionary<string, string> properties)
        {
            Type type = typeof(T);
            T obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

            List<string> parameters = new List<string>();

            foreach (KeyValuePair<string, string> item in properties)
            {
                parameters.Add($"{item.Key} = '{item.Value}'");
            }

            command.CommandText = $"SELECT * FROM {type.Name} WHERE {String.Join(" AND ", parameters)}';";

            OpenConnection();
            MySqlDataReader reader = await command.ExecuteReaderAsync();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo property = type.GetProperty(reader.GetName(i));
                property.SetValue(obj, reader.GetValue(i));
            }

            reader.Close();
            CloseConnection();

            return obj;
        }

        /// <summary>
        /// Добавление объекта.
        /// </summary>
        /// <param name="table">Название таблицы.</param>
        /// <param name="properties">Значения свойств.</param>
        private static void AddObject(string table, Dictionary<string, string> properties)
        {
            command.CommandText = $"INSERT INTO '{table}' ({String.Join(", ", properties.Keys)}) VALUES ({String.Join(", ", properties.Values)});";
            SendDataAsync();
        }

        /// <summary>
        /// Изменение объекта.
        /// </summary>
        /// <param name="table">Название для поиска.</param>
        /// <param name="properties">Свойства для поиска.</param>
        /// <param name="newProperties">Новые значения свойств.</param>
        private static void UpdateObject(string table, Dictionary<string, string> properties, Dictionary<string, string> newProperties)
        {
            List<string> parameters = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"UPDATE {table} SET");

            foreach (KeyValuePair<string, string> item in properties)
            {
                parameters.Add($"{item.Key} = {item.Value}");
            }

            stringBuilder.AppendLine(String.Join(", ", parameters));
            parameters.Clear();

            foreach (KeyValuePair<string, string> item in newProperties)
            {
                parameters.Add($"{item.Key} = '{item.Value}'");
            }

            stringBuilder.AppendLine($"WHERE ({String.Join(" AND ", parameters)});");

            command.CommandText = stringBuilder.ToString();
            SendDataAsync();
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="table">Название таблицы.</param>
        /// <param name="properties">Свойства для поиска объекта.</param>
        private static void DeleteObject(string table, Dictionary<string, string> properties)
        {
            List<string> parameters = new List<string>();

            foreach(KeyValuePair<string, string> item in properties)
            {
                parameters.Add($"{item.Key} = '{item.Value}'");
            }

            command.CommandText = $"DELETE FROM {table} WHERE({String.Join(" AND ", parameters)});";
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
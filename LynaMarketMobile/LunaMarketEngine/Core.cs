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
        /// Строка подключения.
        /// </summary>
        private static readonly string connectionString = new MySqlConnectionStringBuilder()
        {
            Server = server,
            Database = database,
            UserID = user,
            Password = password,
            AllowUserVariables = true
        }.ConnectionString;

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
        public static async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            return await GetObjectsListAsync<ProductCategory>();
        }

        /// <summary>
        /// Получение категории товаров.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <returns>Категория товаров.</returns>
        public static async Task<ProductCategory> GetProductCategoryAsync(int idProductCategory)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProductCategory"] = (MySqlDbType.Int32, idProductCategory)
            };

            return await GetObjectAsync<ProductCategory>(properties);
        }

        /// <summary>
        /// Добавление категории товара.
        /// </summary>
        /// <param name="title">Наименование категории товара.</param>
        public static void AddProductCategory(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
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
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdColor"] = (MySqlDbType.Int32, idColor)
            };

            return await GetObjectAsync<Color>(properties);
        }

        /// <summary>
        /// Добавление цвета.
        /// </summary>
        /// <param name="title">Название цвета.</param>
        public static void AddColor(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
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
        public static async Task<List<DeliveryType>> GetDeliveryTypesAsync()
        {
            return await GetObjectsListAsync<DeliveryType>();
        }

        /// <summary>
        /// Получение типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        /// <returns>Тип доставки.</returns>
        public static async Task<DeliveryType> GetDeliveryTypeAsync(int idDeliveryType)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdDeliveryType"] = (MySqlDbType.Int32, idDeliveryType)
            };

            return await GetObjectAsync<DeliveryType>(properties);
        }

        /// <summary>
        /// Добавление типа доставки.
        /// </summary>
        /// <param name="title">Название типа доставки.</param>
        public static void AddDeliveryType(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
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
        public static async Task<List<Material>> GetMaterialsAsync()
        {
            return await GetObjectsListAsync<Material>();
        }

        /// <summary>
        /// Получение материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <returns>Материал.</returns>
        public static async Task<Material> GetMaterialAsync(int idMaterial)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdMaterial"] = (MySqlDbType.Int32, idMaterial)
            };

            return await GetObjectAsync<Material>(properties);
        }

        /// <summary>
        /// Добавление материала.
        /// </summary>
        /// <param name="title">Название материала.</param>
        public static void AddMaterial(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
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
        public static async Task<List<News>> GetNewsAsync()
        {
            return await GetObjectsListAsync<News>();
        }

        /// <summary>
        /// Получение новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        /// <returns>Новость.</returns>
        public static async Task<News> GetNewsAsync(int idNews)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdNews"] = (MySqlDbType.Int32, idNews)
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
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title),
                ["Date"] = (MySqlDbType.DateTime, date),
                ["Photo"] = (MySqlDbType.LongBlob, photo),
                ["Description"] = (MySqlDbType.String, description)
            };

            AddObject("News", properties);
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
                ["Date"] = date.ToString("yyyy-MM-dd HH:mm:ss"),
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
        public static async Task<ProductInfo> GetProductInfoAsync(int idProduct, int idColor, int idMaterial)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProduct"] = (MySqlDbType.Int32, idProduct),
                ["IdColor"] = (MySqlDbType.Int32, idColor),
                ["IdMaterial"] = (MySqlDbType.Int32, idMaterial)
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
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProduct"] = (MySqlDbType.Int32, idProduct),
                ["IdColor"] = (MySqlDbType.Int32, idColor),
                ["IdMaterial"] = (MySqlDbType.Int32, idMaterial),
                ["Price"] = (MySqlDbType.Decimal, price),
                ["Amount"] = (MySqlDbType.Int32, amount)
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

            UpdateObject("ProductInfo", properties, newProperties);
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
        /// Получение списка заказчиков.
        /// </summary>
        /// <returns>Список заказчиков.</returns>
        public static async Task<List<Customer>> GetCustomersAsync()
        {
            return await GetObjectsListAsync<Customer>();
        }

        /// <summary>
        /// Получение заказчика.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <returns>Заказчик.</returns>
        public static async Task<Customer> GetCustomerAsync(int idCustomer)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdCustomer"] = (MySqlDbType.Int32, idCustomer)
            };

            return await GetObjectAsync<Customer>(properties);
        }

        /// <summary>
        /// Добавление заказчика.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="secondName">Фамилия.</param>
        /// <param name="email">Электронна почта.</param>
        /// <param name="phone">Номер телефона.</param>
        public static void AddCustomer(string login, string password, string firstName, string secondName, string email, string phone)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Login"] = (MySqlDbType.String, login),
                ["Password"] = (MySqlDbType.String, password),
                ["FirstName"] = (MySqlDbType.String, firstName),
                ["SecondName"] = (MySqlDbType.String, secondName),
                ["Email"] = (MySqlDbType.String, email),
                ["Phone"] = (MySqlDbType.String, phone)
            };

            AddObject("Customer", properties);
        }

        /// <summary>
        /// Изменение заказчика.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="secondName">Фамилия.</param>
        /// <param name="email">Электронна почта.</param>
        /// <param name="phone">Номер телефона.</param>
        public static void UpdateCustomer(int idCustomer, string login, string password, string firstName, string secondName, string email, string phone)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdCustomer"] = idCustomer.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Login"] = login,
                ["Password"] = password,
                ["FirstName"] = firstName,
                ["SecondName"] = secondName,
                ["Email"] = email,
                ["Phone"] = phone
            };

            UpdateObject("Customer", properties, newProperties);
        }

        /// <summary>
        /// Удаление заказчика.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        public static void DeleteCustomer(int idCustomer)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdCustomer"] = idCustomer.ToString()
            };

            DeleteObject("Customer", properties);
        }

        /// <summary>
        /// Получение списка производителей.
        /// </summary>
        /// <returns>Список производителей.</returns>
        public static async Task<List<Manufacturer>> GetManufacturersAsync()
        {
            return await GetObjectsListAsync<Manufacturer>();
        }

        /// <summary>
        /// Получение производителя.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор материала.</param>
        /// <returns>Производитель.</returns>
        public static async Task<Manufacturer> GetManufacturerAnsyc(int idManufacturer)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdManufacturer"] = (MySqlDbType.Int32, idManufacturer)
            };

            return await GetObjectAsync<Manufacturer>(properties);
        }

        /// <summary>
        /// Добавление производителя.
        /// </summary>
        /// <param name="title">Название производителя.</param>
        public static void AddManufacturer(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
            };

            AddObject("Manufacturer", properties);
        }

        /// <summary>
        /// Изменение производителя.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор материала.</param>
        /// <param name="title">Название материала.</param>
        public static void UpdateManufacturer(int idManufacturer, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdManufacturer"] = idManufacturer.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("Manufacturer", properties, newProperties);
        }

        /// <summary>
        /// Удаление производителя.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор материала.</param>
        public static void DeleteManufacturer(int idManufacturer)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdManufacturer"] = idManufacturer.ToString()
            };

            DeleteObject("Manufacturer", properties);
        }

        /// <summary>
        /// Получение списка статусов заказов.
        /// </summary>
        /// <returns>Список статусов заказов.</returns>
        public static async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await GetObjectsListAsync<OrderStatus>();
        }

        /// <summary>
        /// Получение статуса заказа.
        /// </summary>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <returns>Статус заказа.</returns>
        public static async Task<OrderStatus> GetOrderStatusAsync(int idOrderStatus)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdOrderStatus"] = (MySqlDbType.Int32, idOrderStatus)
            };

            return await GetObjectAsync<OrderStatus>(properties);
        }

        /// <summary>
        /// Добавление статуса заказа.
        /// </summary>
        /// <param name="title">Название ствтуса заказа.</param>
        public static void AddOrderStatus(string title)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["Title"] = (MySqlDbType.String, title)
            };

            AddObject("OrderStatus", properties);
        }

        /// <summary>
        /// Изменение статуса заказа.
        /// </summary>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="title">Название статуса заказа.</param>
        public static void UpdateOrderStatus(int idOrderStatus, string title)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrderStatus"] = idOrderStatus.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["Title"] = title
            };

            UpdateObject("OrderStatus", properties, newProperties);
        }

        /// <summary>
        /// Удаление статуса заказа.
        /// </summary>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        public static void DeleteOrderStatus(int idOrderStatus)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrderStatus"] = idOrderStatus.ToString()
            };

            DeleteObject("OrderStatus", properties);
        }

        /// <summary>
        /// Получение списка заказов.
        /// </summary>
        /// <returns>Список заказов.</returns>
        public static async Task<List<Order>> GetOrdersAsync()
        {
            return await GetObjectsListAsync<Order>();
        }

        /// <summary>
        /// Получение заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <returns>Заказ.</returns>
        public static async Task<Order> GetOrderAsync(int idOrder)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdOrder"] = (MySqlDbType.Int32, idOrder)
            };

            return await GetObjectAsync<Order>(properties);
        }

        /// <summary>
        /// Добавление заказа.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="idDeliveryType">Идентификатор типа доставкит.</param>
        /// <param name="date">Дата создания заказа.</param>
        /// <param name="adress">Адрес доставки.</param>
        public static void AddOrder(int idCustomer, int idOrderStatus, int idDeliveryType, DateTime date, string adress)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdCustomer"] = (MySqlDbType.Int32, idCustomer),
                ["idOrderStatus"] = (MySqlDbType.Int32, idOrderStatus),
                ["idDeliveryType"] = (MySqlDbType.Int32, idDeliveryType),
                ["Date"] = (MySqlDbType.DateTime, date),
                ["Adress"] = (MySqlDbType.String, adress)
            };

            AddObject("Order", properties);
        }

        /// <summary>
        /// Изменение заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="idDeliveryType">Идентификатор типа доставкит.</param>
        /// <param name="date">Дата создания заказа.</param>
        /// <param name="adress">Адрес доставки.</param>
        public static void UpdateOrder(int idOrder, int idCustomer, int idOrderStatus, int idDeliveryType, DateTime date, string adress)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrder"] = idOrder.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["IdCustomer"] = idCustomer.ToString(),
                ["IdOrderStatus"] = idOrderStatus.ToString(),
                ["IdDeliveryType"] = idDeliveryType.ToString(),
                ["Date"] = date.ToString("yyyy-MM-dd HH:mm:ss"),
                ["Adress"] = adress.ToString(),
            };

            UpdateObject("Order", properties, newProperties);
        }

        /// <summary>
        /// Удаление заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        public static void DeleteOrder(int idOrder)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrder"] = idOrder.ToString()
            };

            DeleteObject("Order", properties);
        }

        /// <summary>
        /// Получение списка соствов заказов.
        /// </summary>
        /// <returns>Список составов заказов.</returns>
        public static async Task<List<OrderProduct>> GetOrderProductsAsync()
        {
            return await GetObjectsListAsync<OrderProduct>();
        }

        /// <summary>
        /// Получение состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <returns>Состав заказа.</returns>
        public static async Task<OrderProduct> GetOrderProductAsync(int idOrder, int idProduct)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdOrder"] = (MySqlDbType.Int32, idOrder),
                ["IdProduct"] = (MySqlDbType.Int32, idProduct)
            };

            return await GetObjectAsync<OrderProduct>(properties);
        }

        /// <summary>
        /// Добавление состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        public static void AddOrderProduct(int idOrder, int idProduct, decimal price, int amount)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdOrder"] = (MySqlDbType.Int32, idOrder),
                ["IdProduct"] = (MySqlDbType.Int32, idProduct),
                ["Price"] = (MySqlDbType.Decimal, price),
                ["Amount"] = (MySqlDbType.Int32, amount)
            };

            AddObject("OrderProduct", properties);
        }

        /// <summary>
        /// Изменение состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="newIdOrder">Новый идентификатор заказа.</param>
        /// <param name="newIdProduct">Новый идентификатор товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        public static void UpdateOrder(int idOrder, int idProduct, int newIdOrder, int newIdProduct, decimal price, int amount)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrder"] = idOrder.ToString(),
                ["IdProduct"] = idProduct.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["IdOrder"] = newIdOrder.ToString(),
                ["IdProduct"] = newIdProduct.ToString(),
                ["Price"] = price.ToString(),
                ["Amount"] = amount.ToString()
            };

            UpdateObject("OrderProduct", properties, newProperties);
        }

        /// <summary>
        /// Удаление состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        public static void DeleteOrder(int idOrder, int idProduct)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdOrder"] = idOrder.ToString(),
                ["IdProduct"] = idProduct.ToString()
            };

            DeleteObject("OrderProduct", properties);
        }

        /// <summary>
        /// Получение списка фотографий товаров.
        /// </summary>
        /// <returns>Список фотографий товаров.</returns>
        public static async Task<List<ProductPhoto>> GetProductsPhotosAsync()
        {
            return await GetObjectsListAsync<ProductPhoto>();
        }

        /// <summary>
        /// Получение фотографии товара.
        /// </summary>
        /// <param name="idProductPhoto">Идентификатор фотографии товара.</param>
        /// <returns>Фотография товара.</returns>
        public static async Task<ProductPhoto> GetProductPhototAsync(int idProductPhoto)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProductPhoto"] = (MySqlDbType.Int32, idProductPhoto)
            };

            return await GetObjectAsync<ProductPhoto>(properties);
        }

        /// <summary>
        /// Добавление фотографии товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="image">Изображение.</param>
        public static void AddProductPhoto(int idProduct, byte[] image)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProduct"] = (MySqlDbType.Int32, idProduct),
                ["Image"] = (MySqlDbType.LongBlob, image)
            };

            AddObject("ProductPhoto", properties);
        }

        /// <summary>
        /// Изменение фотографии товара.
        /// </summary>
        /// <param name="idProductPhoto">Идентификатор фотографии продукта.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="image">Изображение.</param>
        public static void UpdateProductPhoto(int idProductPhoto, int idProduct, byte[] image)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProductPhoto"] = idProductPhoto.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString(),
                ["Image"] = String.Concat(image.Select(data => data.ToString()))
            };

            UpdateObject("ProductPhoto", properties, newProperties);
        }

        /// <summary>
        /// Удаление фотографии товара.
        /// </summary>
        /// <param name="idProductPhoto">Идентификатор фотографии продукта.</param>
        public static void DeleteProductPhoto(int idProductPhoto)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProductPhoto"] = idProductPhoto.ToString()
            };

            DeleteObject("ProductPhoto", properties);
        }

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public static async Task<List<Product>> GetProductsAsync()
        {
            return await GetObjectsListAsync<Product>();
        }

        /// <summary>
        /// Получение товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <returns>Товар.</returns>
        public static async Task<Product> GetProductAsync(int idProduct)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdProduct"] = (MySqlDbType.Int32, idProduct)
            };

            return await GetObjectAsync<Product>(properties);
        }

        /// <summary>
        /// Добавление товара.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор производителя.</param>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="idProductPhoto">Идентификатор фотографии товара.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="height">Выстота товара.</param>
        /// <param name="width">Ширина товара.</param>
        /// <param name="depth">Глубина товара.</param>
        /// <param name="description">Описание товара.</param>
        /// <param name="deleted">Удалён ли товар.</param>
        public static void AddProduct(int idManufacturer, int idProductCategory, int idProductPhoto, string title, int height, int width, int depth, string description, bool deleted = false)
        {
            Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>
            {
                ["IdManufacturer"] = (MySqlDbType.Int32, idManufacturer),
                ["IdProductCategory"] = (MySqlDbType.Int32, idProductCategory),
                ["IdProductPhoto"] = (MySqlDbType.Int32, idProductPhoto),
                ["Title"] = (MySqlDbType.String, title),
                ["Height"] = (MySqlDbType.Int32, height),
                ["Width"] = (MySqlDbType.Int32, width),
                ["Depth"] = (MySqlDbType.Int32, depth),
                ["Description"] = (MySqlDbType.String, description),
                ["Deleted"] = (MySqlDbType.Bit, deleted)
            };

            AddObject("Product", properties);
        }

        /// <summary>
        /// Изменение товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="idManufacturer">Идентификатор производителя.</param>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="idProductPhoto">Идентификатор фотографии товара.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="height">Выстота товара.</param>
        /// <param name="width">Ширина товара.</param>
        /// <param name="depth">Глубина товара.</param>
        /// <param name="description">Описание товара.</param>
        /// <param name="deleted">Удалён ли товар.</param>
        public static void UpdateProduct(int idProduct, int idManufacturer, int idProductCategory, int idProductPhoto, string title, int height, int width, int depth, string description, bool deleted = false)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString()
            };

            Dictionary<string, string> newProperties = new Dictionary<string, string>
            {
                ["IdManufacturer"] = idManufacturer.ToString(),
                ["IdProductCategory"] = idProductCategory.ToString(),
                ["IdProductPhoto"] = idProductPhoto.ToString(),
                ["Title"] = title,
                ["Height"] = height.ToString(),
                ["Width"] = width.ToString(),
                ["Depth"] = depth.ToString(),
                ["Description"] = description,
                ["Deleted"] = deleted.ToString()
            };

            UpdateObject("Product", properties, newProperties);
        }

        /// <summary>
        /// Удаление товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        public static void DeleteProduct(int idProduct)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                ["IdProduct"] = idProduct.ToString()
            };

            DeleteObject("Product", properties);
        }

        /// <summary>
        /// Открытие подключения к базе данных.
        /// </summary>
        /// <param name="connection">Подключение.</param>
        /// <exception cref="Exception">Ошибка подключения к базе данных.</exception>
        private static void OpenConnection(MySqlConnection connection)
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
        /// <param name="connection">Подключение.</param>
        /// <exception cref="Exception">Ошибка отключения от базы данных.</exception>
        private static void CloseConnection(MySqlConnection connection)
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
        /// <param name="filteringProperties">Свойства фильтрации.</param>
        /// <returns>Список объектов типа.</returns>
        internal static async Task<List<T>> GetObjectsListAsync<T>(Dictionary<string, (MySqlDbType type, object value)> filteringProperties = default)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand()
            {
                Connection = mySqlConnection
            };

            Type type = typeof(T);
            List<T> objectList = new List<T>();

            // Формирование запроса.
            {
                List<string> properties = new List<string>();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"SELECT * FROM {type.Name}");

                if (filteringProperties != default)
                {
                    foreach (KeyValuePair<string, (MySqlDbType type, object value)> item in filteringProperties)
                    {
                        string name = $"{item.Key} = @{item.Key}";
                        properties.Add(name);

                        MySqlParameter parameter = new MySqlParameter(name, item.Value.type)
                        {
                            Value = item.Value.value
                        };

                        command.Parameters.Add(parameter);
                    }

                    stringBuilder.Append($" WHERE({String.Join(" AND ", properties)})");
                }

                stringBuilder.Append(";");
                command.CommandText = stringBuilder.ToString();
            }

            OpenConnection(command.Connection);
            MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                // Создание объекта нужного типа.
                T obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo property = type.GetProperty(reader.GetName(i));
                    property.SetValue(obj, reader.GetValue(i));
                }

                objectList.Add(obj);
            }

            reader.Close();
            CloseConnection(command.Connection);

            return objectList;
        }

        /// <summary>
        /// Получение объекта по идентификатору.
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта.</typeparam>
        /// <param name="properties">Свойства для поиска объекта.</param>
        /// <returns>Полученный объект.</returns>
        internal static async Task<T> GetObjectAsync<T>(Dictionary<string, (MySqlDbType type, object value)> properties)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand()
            {
                Connection = mySqlConnection
            };

            // Создание объекта нужного типа.
            Type type = typeof(T);
            T obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

            List<string> parameters = new List<string>();

            // Формирование запроса.
            foreach (KeyValuePair<string, (MySqlDbType type, object value)> item in properties)
            {
                string name = $"{item.Key} = @{item.Key}";
                parameters.Add(name);

                MySqlParameter parameter = new MySqlParameter(name, item.Value.type)
                {
                    Value = item.Value.value
                };

                command.Parameters.Add(parameter);
            }

            command.CommandText = $"SELECT * FROM {type.Name} WHERE {String.Join(" AND ", parameters)}';";

            OpenConnection(command.Connection);
            MySqlDataReader reader = await command.ExecuteReaderAsync();

            try
            {
                reader.Read();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo property = type.GetProperty(reader.GetName(i));
                    property.SetValue(obj, reader.GetValue(i));
                }

                reader.Close();
            }
            catch (Exception) { }

            CloseConnection(command.Connection);

            return obj;
        }

        /// <summary>
        /// Добавление объекта.
        /// </summary>
        /// <param name="table">Название таблицы.</param>
        /// <param name="properties">Значения свойств.</param>
        internal static void AddObject(string table, Dictionary<string, (MySqlDbType type, object value)> properties)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand()
            {
                Connection = mySqlConnection
            };

            List<string> parametersNames = new List<string>();

            // Добавление параметров.
            foreach (KeyValuePair<string, (MySqlDbType type, object value)> item in properties)
            {
                string name = $"@{item.Key}";
                parametersNames.Add(name);

                MySqlParameter parameter = new MySqlParameter(name, item.Value.type)
                {
                    Value = item.Value.value
                };

                command.Parameters.Add(parameter);
            }

            command.CommandText = $"INSERT INTO {table} ({String.Join(", ", properties.Keys)}) VALUES ({String.Join(", ", parametersNames)});";
            SendDataAsync(command);
        }

        /// <summary>
        /// Изменение объекта.
        /// </summary>
        /// <param name="table">Название для поиска.</param>
        /// <param name="properties">Свойства для поиска.</param>
        /// <param name="newProperties">Новые значения свойств.</param>
        internal static void UpdateObject(string table, Dictionary<string, string> properties, Dictionary<string, string> newProperties)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand()
            {
                Connection = mySqlConnection
            };

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
            SendDataAsync(command);
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <param name="table">Название таблицы.</param>
        /// <param name="properties">Свойства для поиска объекта.</param>
        internal static void DeleteObject(string table, Dictionary<string, string> properties)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand()
            {
                Connection = mySqlConnection
            };

            List<string> parameters = new List<string>();

            foreach(KeyValuePair<string, string> item in properties)
            {
                parameters.Add($"{item.Key} = '{item.Value}'");
            }

            command.CommandText = $"DELETE FROM {table} WHERE({String.Join(" AND ", parameters)});";
            SendDataAsync(command);
        }

        /// <summary>
        /// Отправка данных команды.
        /// </summary>
        /// <param name="command">Команда.</param>
        internal static async void SendDataAsync(MySqlCommand command)
        {
            OpenConnection(command.Connection);
            await command.ExecuteNonQueryAsync();
            CloseConnection(command.Connection);
        }
    }
}
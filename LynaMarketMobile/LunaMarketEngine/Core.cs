using LunaMarketEngine.Entities;
using LunaMarketEngine.QueryConstructors;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
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
        private static readonly string user = "логин";

        /// <summary>
        /// Пароль.
        /// </summary>
        private static readonly string password  = "пароль";

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
            get => database;
        }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public static string User
        {
            get => user;
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public static string Password
        {
            get => password;
        }

        /// <summary>
        /// Строка подключения.
        /// </summary>
        internal static string ConnectionString
        {
            get => connectionString;
        }

        public delegate void ConnectHandle();
        public delegate void DisconnectHandle();
        public static event ConnectHandle Connect;
        public static event DisconnectHandle Disconnect;

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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductCategory", idProductCategory)
            };

            return await GetObjectAsync<ProductCategory>(staticProperties);
        }

        /// <summary>
        /// Добавление категории товара.
        /// </summary>
        /// <param name="title">Наименование категории товара.</param>
        public static async Task<int> AddProductCategory(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await AddObjectAsync<ProductCategory>(staticProperties);
        }

        /// <summary>
        /// Изменение названия категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="title">Новое название категории товара.</param>
        public static void UpdateProductCategory(int idProductCategory, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductCategory", idProductCategory)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<ProductCategory>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление категории товара.
        /// </summary>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        public static void DeleteProductCategory(int idProductCategory)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductCategory", idProductCategory)
            };

            DeleteObject<ProductCategory>(staticProperties);
        }

        /// <summary>
        /// Получение списка цветов.
        /// </summary>
        /// <returns>Список цветов.</returns>
        public static async Task<List<Color>> GetColorsAsync()
        {
            return await GetObjectsListAsync<Color>();
        }

        /// <summary>
        /// Получение цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <returns>Цвет.</returns>
        public static async Task<Color> GetColorAsync(int idColor)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdColor", idColor)
            };

            return await GetObjectAsync<Color>(staticProperties);
        }

        /// <summary>
        /// Добавление цвета.
        /// </summary>
        /// <param name="title">Название цвета.</param>
        public static async Task<int> AddColor(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await AddObjectAsync<Color>(staticProperties);
        }

        /// <summary>
        /// Изменение цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="title">Новое название цвета.</param>
        public static void UpdateColor(int idColor, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdColor", idColor)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<Color>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление  цвета.
        /// </summary>
        /// <param name="idColor">Идентификатор цвета.</param>
        public static void DeleteColor(int idColor)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdColor", idColor)
            };

            DeleteObject<Color>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", idDeliveryType)
            };

            return await GetObjectAsync<DeliveryType>(staticProperties);
        }

        /// <summary>
        /// Добавление типа доставки.
        /// </summary>
        /// <param name="title">Название типа доставки.</param>
        public static Task<int> AddDeliveryType(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return AddObjectAsync<DeliveryType>(staticProperties);
        }

        /// <summary>
        /// Изменение типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        /// <param name="title">Название типа доставки.</param>
        public static void UpdateDeliveryType(int idDeliveryType, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", idDeliveryType)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<DeliveryType>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление типа доставки.
        /// </summary>
        /// <param name="idDeliveryType">Идентификатор типа доставки.</param>
        public static void DeleteDeliveryType(int idDeliveryType)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdDeliveryType", idDeliveryType)
            };

            DeleteObject<DeliveryType>(staticProperties);
        }

        /// <summary>
        /// Получение списка статусов оплаты.
        /// </summary>
        /// <returns>Список статусов оплаты.</returns>
        public static async Task<List<PayStatus>> GetPayStatusesAsync()
        {
            return await GetObjectsListAsync<PayStatus>();
        }

        /// <summary>
        /// Получение статуса оплаты.
        /// </summary>
        /// <param name="idPayStatus">Идентификатор статуса оплаты.</param>
        /// <returns>Статус оплаты.</returns>
        public static async Task<PayStatus> GetPayStatusAsync(int idPayStatus)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPayStatus", idPayStatus)
            };

            return await GetObjectAsync<PayStatus>(staticProperties);
        }

        /// <summary>
        /// Добавление статуса оплаты.
        /// </summary>
        /// <param name="title">Название статуса оплаты.</param>
        public static Task<int> AddPayStatus(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return AddObjectAsync<PayStatus>(staticProperties);
        }

        /// <summary>
        /// Изменение статуса оплаты.
        /// </summary>
        /// <param name="idPayStatus">Идентификатор статуса оплаты.</param>
        /// <param name="title">Название статуса оплаты.</param>
        public static void UpdatePayStatus(int idPayStatus, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPayStatus", idPayStatus)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<PayStatus>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление статуса оплаты.
        /// </summary>
        /// <param name="idPayStatus">Идентификатор статуса оплаты.</param>
        public static void DeletePayStatus(int idPayStatus)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPayStatus", idPayStatus)
            };

            DeleteObject<PayStatus>(staticProperties);
        }

        /// <summary>
        /// Получение списка способов оплаты.
        /// </summary>
        /// <returns>Список способов оплаты.</returns>
        public static async Task<List<PaymentMethod>> GetPaymentMethodsAsync()
        {
            return await GetObjectsListAsync<PaymentMethod>();
        }

        /// <summary>
        /// Получение способа оплаты.
        /// </summary>
        /// <param name="idPaymentMethod">Идентификатор способа оплаты.</param>
        /// <returns>Способа оплаты.</returns>
        public static async Task<PaymentMethod> GetPaymentMethodAsync(int idPaymentMethod)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPaymentMethod", idPaymentMethod)
            };

            return await GetObjectAsync<PaymentMethod>(staticProperties);
        }

        /// <summary>
        /// Добавление способа оплаты.
        /// </summary>
        /// <param name="title">Название способа оплаты.</param>
        public static Task<int> AddPaymentMethod(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return AddObjectAsync<PaymentMethod>(staticProperties);
        }

        /// <summary>
        /// Изменение способа оплаты.
        /// </summary>
        /// <param name="idPaymentMethod">Идентификатор способа оплаты.</param>
        /// <param name="title">Название способа оплаты.</param>
        public static void UpdatePaymentMethod(int idPaymentMethod, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPaymentMethod", idPaymentMethod)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<PaymentMethod>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление статуса оплаты.
        /// </summary>
        /// <param name="idPaymentMethod">Идентификатор способа оплаты.</param>
        public static void DeletePaymentMethod(int idPaymentMethod)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdPaymentMethod", idPaymentMethod)
            };

            DeleteObject<PaymentMethod>(staticProperties);
        }

        /// <summary>
        /// Получение списка адресов офисов.
        /// </summary>
        /// <returns>Список адресов.</returns>
        public static async Task<List<OfficeAddress>> GetOfficeAddressesAsync()
        {
            return await GetObjectsListAsync<OfficeAddress>();
        }

        /// <summary>
        /// Получение адреса офиса.
        /// </summary>
        /// <param name="idOfficeAddress">Идентификатор адреса офиса.</param>
        /// <returns>Адрес офиса.</returns>
        public static async Task<OfficeAddress> GetOfficeAddressAsync(int idOfficeAddress)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOfficeAddress", idOfficeAddress)
            };

            return await GetObjectAsync<OfficeAddress>(staticProperties);
        }

        /// <summary>
        /// Добавление адреса офиса.
        /// </summary>
        /// <param name="title">Адрес офиса.</param>
        /// <returns>Идентификатор адреса офиса.</returns>
        public static Task<int> AddOfficeAddress(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return AddObjectAsync<OfficeAddress>(staticProperties);
        }

        /// <summary>
        /// Изменение адреса офиса.
        /// </summary>
        /// <param name="idOfficeAddress">Идентификатор адреса офиса.</param>
        /// <param name="title">Адрес офиса.</param>
        public static void UpdateOfficeAddress(int idOfficeAddress, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOfficeAddress", idOfficeAddress)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<OfficeAddress>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление адреса офиса.
        /// </summary>
        /// <param name="idOfficeAddress">Идентификатор адреса офиса.</param>
        public static void DeleteOfficeAddress(int idOfficeAddress)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOfficeAddress", idOfficeAddress)
            };

            DeleteObject<OfficeAddress>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdMaterial", idMaterial)
            };

            return await GetObjectAsync<Material>(staticProperties);
        }

        /// <summary>
        /// Добавление материала.
        /// </summary>
        /// <param name="title">Название материала.</param>
        public static async Task<int> AddMaterial(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await AddObjectAsync<Material>(staticProperties);
        }

        /// <summary>
        /// Изменение материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="title">Название материала.</param>
        public static void UpdateMaterial(int idMaterial, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdMaterial", idMaterial)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<Material>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление материала.
        /// </summary>
        /// <param name="idMaterial">Идентификатор материала.</param>
        public static void DeleteMaterial(int idMaterial)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdMaterial", idMaterial)
            };

            DeleteObject<Material>(staticProperties);
        }

        /// <summary>
        /// Получение списка новостей.
        /// </summary>
        /// <returns>Список новостей.</returns>
        public static async Task<List<News>> GetNewsAsync(int take = 5, List<SortingProperty> sortingProperties = default)
        {
            return await GetObjectsListAsync<News>(take: take, sortingProperties: sortingProperties);
        }

        /// <summary>
        /// Получение новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        /// <returns>Новость.</returns>
        public static async Task<News> GetNewsAsync(int idNews)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdNews", idNews)
            };

            return await GetObjectAsync<News>(staticProperties);
        }

        /// <summary>
        /// Добавление новости.
        /// </summary>
        /// <param name="title">Заголовок новости.</param>
        /// <param name="date">Дата публикации новости.</param>
        /// <param name="photo">Изображение новости.</param>
        /// <param name="description">Описание новости.</param>
        public static async Task<int> AddNews(string title, DateTime date, byte[] photo, string description)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title),
                new StaticProperty("Date", date),
                new StaticProperty("Photo", photo),
                new StaticProperty("Description", description)
            };

            return await AddObjectAsync<News>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdNews", idNews)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title),
                new StaticProperty("Date", date),
                new StaticProperty("Photo", photo),
                new StaticProperty("Description", description)
            };

            UpdateObject<News>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление новости.
        /// </summary>
        /// <param name="idNews">Идентификатор новости.</param>
        public static void DeleteNews(int idNews)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdNews", idNews)
            };

            DeleteObject<News>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", idCustomer)
            };

            return await GetObjectAsync<Customer>(staticProperties);
        }

        /// <summary>
        /// Получение заказчика.
        /// </summary>
        /// <param name="loginOrEmailOrPhone">Логин или почта или пароль.</param>
        /// <returns>Заказчик.</returns>
        public static async Task<Customer> GetCustomerAsync(string loginOrEmailOrPhone)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Login", loginOrEmailOrPhone)
            };

            Customer customer = await GetObjectAsync<Customer>(staticProperties);

            if (customer == null)
            {
                staticProperties[0].ColumnName = "Email";
                customer = await GetObjectAsync<Customer>(staticProperties);
            }

            if (customer == null)
            {
                staticProperties[0].ColumnName = "Phone";
                customer = await GetObjectAsync<Customer>(staticProperties);
            }

            return customer;
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
        public static async Task<int> AddCustomer(string login, string password, string firstName, string secondName, string email, string phone)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Login", login),
                new StaticProperty("Password", password),
                new StaticProperty("FirstName", firstName),
                new StaticProperty("SecondName", secondName),
                new StaticProperty("Email", email),
                new StaticProperty("Phone", phone)
            };

            return await AddObjectAsync<Customer>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", idCustomer)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Login", login),
                new StaticProperty("Password", password),
                new StaticProperty("FirstName", firstName),
                new StaticProperty("SecondName", secondName),
                new StaticProperty("Email", email),
                new StaticProperty("Phone", phone)
            };

            UpdateObject<Customer>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление заказчика.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        public static void DeleteCustomer(int idCustomer)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", idCustomer)
            };

            DeleteObject<Customer>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", idManufacturer)
            };

            return await GetObjectAsync<Manufacturer>(staticProperties);
        }

        /// <summary>
        /// Добавление производителя.
        /// </summary>
        /// <param name="title">Название производителя.</param>
        public static async Task<int> AddManufacturer(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await AddObjectAsync<Manufacturer>(staticProperties);
        }

        /// <summary>
        /// Изменение производителя.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор материала.</param>
        /// <param name="title">Название материала.</param>
        public static void UpdateManufacturer(int idManufacturer, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", idManufacturer)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<Manufacturer>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление производителя.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор материала.</param>
        public static void DeleteManufacturer(int idManufacturer)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", idManufacturer)
            };

            DeleteObject<Manufacturer>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", idOrderStatus)
            };

            return await GetObjectAsync<OrderStatus>(staticProperties);
        }

        /// <summary>
        /// Получение статуса заказа.
        /// </summary>
        /// <param name="title">Название статуса заказа.</param>
        /// <returns>Статус заказа.</returns>
        public static async Task<OrderStatus> GetOrderStatusAsync(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await GetObjectAsync<OrderStatus>(staticProperties);
        }

        /// <summary>
        /// Добавление статуса заказа.
        /// </summary>
        /// <param name="title">Название ствтуса заказа.</param>
        public static async Task<int> AddOrderStatus(string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            return await AddObjectAsync<OrderProduct>(staticProperties);
        }

        /// <summary>
        /// Изменение статуса заказа.
        /// </summary>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="title">Название статуса заказа.</param>
        public static void UpdateOrderStatus(int idOrderStatus, string title)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", idOrderStatus)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("Title", title)
            };

            UpdateObject<OrderStatus>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление статуса заказа.
        /// </summary>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        public static void DeleteOrderStatus(int idOrderStatus)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrderStatus", idOrderStatus)
            };

            DeleteObject<OrderStatus>(staticProperties);
        }

        /// <summary>
        /// Получение списка заказов.
        /// </summary>
        /// <param name="staticProperties">Параметры поиска.</param>
        /// <param name="sortingProperties">Параметры сортировки.</param>
        /// <param name="skip">Пропустить.</param>
        /// <param name="take">Взять</param>
        /// <returns>Список заказов.</returns>
        public static async Task<List<Order>> GetOrdersAsync(List<StaticProperty> staticProperties = default, List<SortingProperty> sortingProperties = default, 
            int skip = 0, int take = Int32.MaxValue)
        {
            return await GetObjectsListAsync<Order>(staticProperties, sortingProperties: sortingProperties, skip: skip, take: take);
        }

        /// <summary>
        /// Получение заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <returns>Заказ.</returns>
        public static async Task<Order> GetOrderAsync(int idOrder)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder)
            };

            return await GetObjectAsync<Order>(staticProperties);
        }

        /// <summary>
        /// Получение количества заказов.
        /// </summary>
        /// <param name="staticProperties">Параметры поиска.</param>
        /// <returns>Количество заказов.</returns>
        public static async Task<long> GetOrdersCountAsync(List<StaticProperty> staticProperties)
        {
            return await GetObjectsCount<Order>(staticProperties);
        }

        /// <summary>
        /// Добавление заказа.
        /// </summary>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="idPaymentMethod">Идентификатор способа оплаты</param>
        /// <param name="idPayStatus">Идентификатор статуса оплаты.</param>
        /// <param name="idDeliveryType">Идентификатор типа доставкит.</param>
        /// <param name="date">Дата создания заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        public static async Task<int> AddOrder(int idCustomer, int idOrderStatus, int idPaymentMethod, int idPayStatus, int idDeliveryType, DateTime date, string address)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", idCustomer),
                new StaticProperty("idOrderStatus", idOrderStatus),
                new StaticProperty("IdPaymentMethod", idPaymentMethod),
                new StaticProperty("IdPayStatus", idPayStatus),
                new StaticProperty("idDeliveryType", idDeliveryType),
                new StaticProperty("Date", date),
                new StaticProperty("Address", address)
            };

            return await AddObjectAsync<Order>(staticProperties);
        }

        /// <summary>
        /// Изменение заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idCustomer">Идентификатор заказчика.</param>
        /// <param name="idOrderStatus">Идентификатор статуса заказа.</param>
        /// <param name="idPaymentMethod">Идентификатор способа оплаты</param>
        /// <param name="idPayStatus">Идентификатор статуса оплаты.</param>
        /// <param name="idDeliveryType">Идентификатор типа доставкит.</param>
        /// <param name="date">Дата создания заказа.</param>
        /// <param name="address">Адрес доставки.</param>
        public static void UpdateOrder(int idOrder, int idCustomer, int idOrderStatus, int idPaymentMethod, int idPayStatus, int idDeliveryType, DateTime date, string address)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdCustomer", idCustomer),
                new StaticProperty("idOrderStatus", idOrderStatus),
                new StaticProperty("IdPaymentMethod", idPaymentMethod),
                new StaticProperty("IdPayStatus", idPayStatus),
                new StaticProperty("idDeliveryType", idDeliveryType),
                new StaticProperty("Date", date),
                new StaticProperty("Address", address)
            };

            UpdateObject<Order>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        public static void DeleteOrder(int idOrder)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder)
            };

            DeleteObject<Order>(staticProperties);
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
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder),
                new StaticProperty("IdProduct", idProduct)
            };

            return await GetObjectAsync<OrderProduct>(staticProperties);
        }

        /// <summary>
        /// Добавление состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        public static async Task<int> AddOrderProduct(int idOrder, int idProduct, decimal price, int amount)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder),
                new StaticProperty("IdProduct", idProduct),
                new StaticProperty("Price", price),
                new StaticProperty("Amount", amount)
            };

            return await AddObjectAsync<OrderProduct>(staticProperties);
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
        public static void UpdateOrderProduct(int idOrder, int idProduct, int newIdOrder, int newIdProduct, decimal price, int amount)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder),
                new StaticProperty("IdProduct", idProduct)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", newIdOrder),
                new StaticProperty("IdProduct", newIdProduct),
                new StaticProperty("Price", price),
                new StaticProperty("Amount", amount)
            };

            UpdateObject<OrderProduct>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление состава заказа.
        /// </summary>
        /// <param name="idOrder">Идентификатор заказа.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        public static void DeleteOrderProduct(int idOrder, int idProduct)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdOrder", idOrder),
                new StaticProperty("IdProduct", idProduct)
            };

            DeleteObject<OrderProduct>(staticProperties);
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
        public static async Task<ProductPhoto> GetProductPhotoAsync(int idProductPhoto)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductPhoto", idProductPhoto)
            };

            return await GetObjectAsync<ProductPhoto>(staticProperties);
        }

        /// <summary>
        /// Добавление фотографии товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="image">Изображение.</param>
        public static async Task<int> AddProductPhoto(int idProduct, byte[] image)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", idProduct),
                new StaticProperty("Image", image)
            };

            return await AddObjectAsync<ProductPhoto>(staticProperties);
        }

        /// <summary>
        /// Изменение фотографии товара.
        /// </summary>
        /// <param name="idProductPhoto">Идентификатор фотографии продукта.</param>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="image">Изображение.</param>
        public static void UpdateProductPhoto(int idProductPhoto, int idProduct, byte[] image)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductPhoto", idProductPhoto)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", idProduct),
                new StaticProperty("Image", image)
            };

            UpdateObject<ProductPhoto>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление фотографии товара.
        /// </summary>
        /// <param name="idProductPhoto">Идентификатор фотографии продукта.</param>
        public static void DeleteProductPhoto(int idProductPhoto)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductPhoto", idProductPhoto)
            };

            DeleteObject<ProductPhoto>(staticProperties);
        }

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        /// <param name="staticProperties">Свойства с постоянным значением.</param>
        /// <param name="betweenProperties">Свойста с диапазоном.</param>
        /// <param name="multiProperties">Свойста с множеством значений.</param>
        /// <param name="skip">Пропустить.</param>
        /// <param name="take">Взять.</param>
        /// <param name="sortingProperties">Колонки для сортировки.</param>
        /// <param name="livensgtainProperty">Свойство для растояния Лиывенштейна.</param>
        /// <returns>Список товаров.</returns>
        public static async Task<List<Product>> GetProductsAsync(List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default,
            int skip = 0, int take = Int32.MaxValue, List<SortingProperty> sortingProperties = default, LivensgtainProperty livensgtainProperty = default)
        {
            return await GetObjectsListAsync<Product>(staticProperties, betweenProperties, multiProperties, skip, take, sortingProperties, livensgtainProperty);
        }

        /// <summary>
        /// Получение товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <returns>Товар.</returns>
        public static async Task<Product> GetProductAsync(int idProduct)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", idProduct)
            };

            return await GetObjectAsync<Product>(staticProperties);
        }

        /// <summary>
        /// Получение количесва товара.
        /// </summary>
        /// <param name="staticProperties">Постоянные свойства объекта.</param>
        /// <param name="betweenProperties">Свойства объекта с диапазоном.</param>
        /// <param name="multiProperties">Свойства объекта с множеством значений.</param>
        /// <param name="livensgtainProperty">Свойство для растояния Лиывенштейна.</param>
        /// <returns>Количество товара.</returns>
        public static async Task<long> GetProductCountAsync(List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default, LivensgtainProperty livensgtainProperty = default)
        {
            return await GetObjectsCount<Product>(staticProperties, betweenProperties, multiProperties, livensgtainProperty);
        }

        /// <summary>
        /// Добавление товара.
        /// </summary>
        /// <param name="idManufacturer">Идентификатор производителя.</param>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        /// <param name="height">Выстота товара.</param>
        /// <param name="width">Ширина товара.</param>
        /// <param name="depth">Глубина товара.</param>
        /// <param name="description">Описание товара.</param>
        /// <param name="deleted">Удалён ли товар.</param>
        public static async Task<int> AddProduct(int idManufacturer, int idProductCategory, int idColor, int idMaterial, string title,
            decimal price, int amount, int height, int width, int depth, string description, bool deleted = false)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", idManufacturer),
                new StaticProperty("IdProductCategory", idProductCategory),
                new StaticProperty("IdColor", idColor),
                new StaticProperty("IdMaterial", idMaterial),
                new StaticProperty("Title", title),
                new StaticProperty("Price", price),
                new StaticProperty("Amount", amount),
                new StaticProperty("Height", height),
                new StaticProperty("Width", width),
                new StaticProperty("Depth", depth),
                new StaticProperty("Description", description),
                new StaticProperty("Deleted", deleted)
            };

            return await AddObjectAsync<Product>(staticProperties);
        }

        /// <summary>
        /// Изменение товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="idManufacturer">Идентификатор производителя.</param>
        /// <param name="idProductCategory">Идентификатор категории товара.</param>
        /// <param name="idColor">Идентификатор цвета.</param>
        /// <param name="idMaterial">Идентификатор материала.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        /// <param name="height">Выстота товара.</param>
        /// <param name="width">Ширина товара.</param>
        /// <param name="depth">Глубина товара.</param>
        /// <param name="description">Описание товара.</param>
        /// <param name="deleted">Удалён ли товар.</param>
        public static void UpdateProduct(int idProduct, int idManufacturer, int idProductCategory, int idColor, int idMaterial, string title,
            decimal price, int amount, int height, int width, int depth, string description, bool deleted = false)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", idProduct)
            };

            List<StaticProperty> setStaticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", idManufacturer),
                new StaticProperty("IdProductCategory", idProductCategory),
                new StaticProperty("IdColor", idColor),
                new StaticProperty("IdMaterial", idMaterial),
                new StaticProperty("Title", title),
                new StaticProperty("Price", price),
                new StaticProperty("Amount", amount),
                new StaticProperty("Height", height),
                new StaticProperty("Width", width),
                new StaticProperty("Depth", depth),
                new StaticProperty("Description", description),
                new StaticProperty("Deleted", deleted)
            };

            UpdateObject<Product>(setStaticProperties, staticProperties);
        }

        /// <summary>
        /// Удаление товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        public static void DeleteProduct(int idProduct)
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", idProduct)
            };

            DeleteObject<Product>(staticProperties);
        }

        /// <summary>
        /// Открытие подключения к базе данных.
        /// </summary>
        /// <param name="connection">Подключение.</param>
        /// <exception cref="Exception">Ошибка подключения к базе данных.</exception>
        private static void OpenConnection(MySqlConnection connection)
        {
            bool isDisconectd = false;

            while (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();

                    if (isDisconectd)
                    {
                        isDisconectd = false;
                        Connect?.Invoke();  
                    }
                }
                catch (Exception)
                {
                    if (!isDisconectd)
                    {
                        Disconnect?.Invoke();
                        isDisconectd = true;
                    }

                    System.Threading.Thread.Sleep(500);
                }
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
        /// <param name="staticProperties">Постоянные свойства объекта.</param>
        /// <param name="betweenProperties">Свойства объекта с диапазоном.</param>
        /// <param name="multiProperties">Свойства объекта с множеством значений.</param>
        /// <param name="sortingProperties">Колонки для сортировки.</param>
        /// <param name="skip">Пропутить.</param>
        /// <param name="take">Взять.</param>
        /// <param name="livensgtainProperty">Свойство для растояния Лиывенштейна.</param>
        /// <returns>Список объектов указанного типа.</returns>
        internal static async Task<List<T>> GetObjectsListAsync<T>(List<StaticProperty> staticProperties = default, 
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default, 
            int skip = 0, int take = Int32.MaxValue, List<SortingProperty> sortingProperties = default, LivensgtainProperty livensgtainProperty = default)
        {
            MySqlCommand command = default;

            try
            {
                // Создание команды и подключения.
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }

            List<T> objectList = new List<T>();
            Type type = typeof(T);

            SelectQuery selectQuery = new SelectQuery(type.Name, staticProperties, betweenProperties, multiProperties, sortingProperties,
                livensgtainProperty, take, skip);

            foreach (var item in selectQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = selectQuery.ToString();

            try
            {
                OpenConnection(command.Connection);
                MySqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    // Создание объекта нужного типа.
                    T obj = (T)typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { });

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            PropertyInfo property = type.GetProperty(reader.GetName(i));
                            property.SetValue(obj, Convert.ChangeType(reader.GetValue(i), property.PropertyType));
                        }
                        catch (Exception) { }
                    }

                    objectList.Add(obj);
                }

                reader.Close();
                CloseConnection(command.Connection);
            }
            catch (Exception) { }

            command.Connection.Dispose();
            command.Dispose();
            return objectList;
        }

        /// <summary>
        /// <summary>
        /// Получение объекта по идентификатору.
        /// </summary>
        /// <typeparam name="T">Тип получаемого объекта.</typeparam>
        /// <param name="staticProperties"></param>
        /// <returns>Полученный объект.</returns>
        internal static async Task<T> GetObjectAsync<T>(List<StaticProperty> staticProperties)
        {
            MySqlCommand command = default;

            try
            {
                // Создание команды и подключения.
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }
            

            // Создание объекта нужного типа.
            Type type = typeof(T);
            T obj = default;

            SelectQuery selectQuery = new SelectQuery(type.Name, staticProperties);

            foreach (var item in selectQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = selectQuery.ToString();

            try
            {
                OpenConnection(command.Connection);
                MySqlDataReader reader = await command.ExecuteReaderAsync();
                reader.Read();

                if (!reader.HasRows)
                {
                    throw new Exception();
                }

                obj = (T)type.GetConstructor(new Type[] { }).Invoke(new object[] { });

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo property = type.GetProperty(reader.GetName(i));
                    property.SetValue(obj, Convert.ChangeType(reader.GetValue(i), property.PropertyType)); 
                }

                reader.Close();
                CloseConnection(command.Connection);
            }
            catch (Exception) { }

            command.Connection.Dispose();
            command.Dispose();

            return obj;
        }

        /// <summary>
        /// Получение количества записей.
        /// </summary>
        /// <typeparam name="T">Тип сущности для расчёта.</typeparam>
        /// <param name="staticProperties">Постоянные свойства объекта.</param>
        /// <param name="betweenProperties">Свойства объекта с диапазоном.</param>
        /// <param name="multiProperties">Свойства объекта с множеством значений.</param>
        /// <param name="livensgtainProperty">Свойство для растояния Лиывенштейна.</param>
        /// <returns>Количесво записей.</returns>
        internal static async Task<long> GetObjectsCount<T>(List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default, 
            LivensgtainProperty livensgtainProperty = default)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = default;
            MySqlCommand command = default;

            try
            {
                mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }

            CountQuery countQuery = new CountQuery(typeof(T).Name, staticProperties, 
                betweenProperties, multiProperties, livensgtainProperty);

            foreach (var item in countQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = countQuery.ToString();
            long count;

            try
            {
                OpenConnection(mySqlConnection);
                count = (long)await command.ExecuteScalarAsync();
                CloseConnection(mySqlConnection);
            }
            catch (Exception)
            {
                count = 0;
            }

            command.Connection.Dispose();
            command.Dispose();

            return count;
        }

        /// <summary>
        /// Добавление объекта.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="staticProperties">Свойства объекта.</param>
        internal static async Task<int> AddObjectAsync<T>(List<StaticProperty> staticProperties)
        {
            // Создание команды и подключения.
            MySqlConnection mySqlConnection = default;
            MySqlCommand command = default;

            try
            {
                mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }

            AddQuery addQuery = new AddQuery(typeof(T).Name, staticProperties);

            foreach (var item in addQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = addQuery.ToString();

            int id;

            try
            {
                OpenConnection(mySqlConnection);
                id = Convert.ToInt32(await command.ExecuteScalarAsync());
                CloseConnection(mySqlConnection);
            }
            catch (Exception)
            {
                id = -1;
            }

            command.Connection.Dispose();

            return id;
        }

        /// <summary>
        /// Изменение объекта.
        /// </summary>
        /// <typeparam name="T">тип объекта.</typeparam>
        /// <param name="setStaticProperties">Новые свойства объекта.</param>
        /// <param name="staticProperties">Постоянные свойства объекта.</param>
        /// <param name="betweenProperties">Свойства объекта с диапазоном.</param>
        /// <param name="multiProperties">Свойства объекта с множеством значений.</param>
        internal static void UpdateObject<T>(List<StaticProperty> setStaticProperties, List<StaticProperty> staticProperties = default, 
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default)
        {
            MySqlCommand command = default;

            try
            {
                // Создание команды и подключения.
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }

            UpdateQuery updateQuery = new UpdateQuery(typeof(T).Name, setStaticProperties, staticProperties, betweenProperties, multiProperties);

            foreach (var item in updateQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = updateQuery.ToString();
            SendDataAsync(command);
        }

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        /// <typeparam name="T">Тип удаляемого объекта.</typeparam>
        /// <param name="staticProperties">Постоянные свойства объекта.</param>
        /// <param name="betweenProperties">Свойства объекта с диапазоном.</param>
        /// <param name="multiProperties">Свойства объекта с множеством значений.</param>
        internal static void DeleteObject<T>(List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default)
        {
            MySqlCommand command = default;

            try
            {
                // Создание команды и подключения.
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                command = new MySqlCommand()
                {
                    Connection = mySqlConnection
                };
            }
            catch (Exception) { }

            DeleteQuery deleteQuery = new DeleteQuery(typeof(T).Name, staticProperties, betweenProperties, multiProperties);

            foreach (var item in deleteQuery.Parameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText= deleteQuery.ToString();
            SendDataAsync(command);
            command.Connection.Dispose();
        }

        /// <summary>
        /// Отправка данных команды.
        /// </summary>
        /// <param name="command">Команда.</param>
        internal static async void SendDataAsync(MySqlCommand command)
        {
            try
            {
                OpenConnection(command.Connection);
                await command.ExecuteNonQueryAsync();
                CloseConnection(command.Connection);
            }
            catch (Exception) { }
        }
    }
}

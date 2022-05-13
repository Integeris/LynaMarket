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
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Идентификатор производителя.
        /// </summary>
        public int IdManufacturer { get; set; }

        /// <summary>
        /// Идентификатор категории товара.
        /// </summary>
        public int IdProductCategory { get; set; }

        /// <summary>
        /// Идентификатор цвета.
        /// </summary>
        public int IdColor { get; set; }

        /// <summary>
        /// Идентификатор материала.
        /// </summary>
        public int IdMaterial { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Глубина.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Удалён?
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Получение категории товара.
        /// </summary>
        /// <returns>Категория товара.</returns>
        public async Task<ProductCategory> GetProductCategoryAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductCategory", IdProductCategory)
            };

            return await Core.GetObjectAsync<ProductCategory>(staticProperties);
        }

        /// <summary>
        /// Получение цвета.
        /// </summary>
        /// <returns>Цвет.</returns>
        public async Task<Color> GetProductColorAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdColor", IdColor)
            };

            return await Core.GetObjectAsync<Color>(staticProperties);
        }

        /// <summary>
        /// Получение материала.
        /// </summary>
        /// <returns>Материал.</returns>
        public async Task<Material> GetMaterialAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdMaterial", IdMaterial)
            };

            return await Core.GetObjectAsync<Material>(staticProperties);
        }

        /// <summary>
        /// Получение производителя.
        /// </summary>
        /// <returns>Производитель.</returns>
        public async Task<Manufacturer> GetManufacturerAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", IdManufacturer)
            };

            return await Core.GetObjectAsync<Manufacturer>(staticProperties);
        }

        /// <summary>
        /// Получение списка фотографий продукта.
        /// </summary>
        /// <returns>Список фотографий продукта.</returns>
        public async Task<List<ProductPhoto>> GetProductPhotoAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", IdProduct)
            };

            return await Core.GetObjectsListAsync<ProductPhoto>(staticProperties);
        }

        /// <summary>
        /// Получение списка заказов с товаром.
        /// </summary>
        /// <returns>Список заказов с товаром.</returns>
        public List<OrderProduct> OrdersProduct
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdProduct", IdProduct)
                };

                return Core.GetObjectsListAsync<OrderProduct>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Получение списка заказов с продуктом.
        /// </summary>
        /// <returns>Список заказов с продуктом.</returns>
        public async Task<List<OrderProduct>> GetOrderProductsAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", IdProduct)
            };

            return await Core.GetObjectsListAsync<OrderProduct>(staticProperties);
        }
    }
}
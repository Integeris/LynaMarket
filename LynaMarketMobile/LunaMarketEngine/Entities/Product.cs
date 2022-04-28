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
        /// Идентификатор фотографии товара.
        /// </summary>
        public int IdProductPhoto { get; set; }

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
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Удалён?
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        public ProductCategory ProductCategory
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdProductCategory", IdProductCategory)
                };

                return Core.GetObjectAsync<ProductCategory>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Фотографии продукта.
        /// </summary>
        public List<ProductPhoto> OrderProducts
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdProductPhoto", IdProductPhoto)
                };

                return Core.GetObjectsListAsync<ProductPhoto>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Производитель.
        /// </summary>
        public Manufacturer Manufacturer
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdManufacturer", IdManufacturer)
                };

                return Core.GetObjectAsync<Manufacturer>(staticProperties).Result;
            }
        }
    }
}
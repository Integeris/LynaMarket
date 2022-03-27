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
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdProductCategory"] = IdProductCategory.ToString()
                };

                return Core.GetObjectAsync<ProductCategory>(properties).Result;
            }
        }

        /// <summary>
        /// Фотографии продукта.
        /// </summary>
        public List<ProductPhoto> OrderProducts
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdProductPhoto"] = IdProductPhoto.ToString()
                };

                return Core.GetObjectsListAsync<ProductPhoto>(properties).Result;
            }
        }

        /// <summary>
        /// Производитель.
        /// </summary>
        public Manufacturer Manufacturer
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdManufacturer"] = IdManufacturer.ToString()
                };

                return Core.GetObjectAsync<Manufacturer>(properties).Result;
            }
        }
    }
}
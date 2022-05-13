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
    /// Фотография товара.
    /// </summary>
    public class ProductPhoto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdProductPhoto { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Изображение.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Получение товара.
        /// </summary>
        /// <returns>Товар.</returns>
        public async Task<Product> GetProductPhotoAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProduct", IdProduct)
            };

            return await Core.GetObjectAsync<Product>(staticProperties);
        }
    }
}
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
    /// Категория товара.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdProductCategory { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Товары.
        /// </summary>
        public async Task<List<Product>> GetProductsAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdProductCategory", IdProductCategory)
            };

            return await Core.GetObjectsListAsync<Product>(staticProperties);
        }
    }
}

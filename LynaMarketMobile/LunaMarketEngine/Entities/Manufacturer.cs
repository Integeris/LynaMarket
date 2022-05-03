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
    /// Производитель.
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdManufacturer { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Товары производителя.
        /// </summary>
        public async Task<List<Product>> GetProductsAsync()
        {
            List<StaticProperty> staticProperties = new List<StaticProperty>()
            {
                new StaticProperty("IdManufacturer", IdManufacturer)
            };

            return await Core.GetObjectsListAsync<Product>(staticProperties);
        }
    }
}

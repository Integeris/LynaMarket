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
        public List<Product> Products
        {
            get
            {
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdProductCategory"] = (MySqlDbType.Int32, IdProductCategory)
                };

                return Core.GetObjectsListAsync<Product>(properties).Result;
            }
        }
    }
}

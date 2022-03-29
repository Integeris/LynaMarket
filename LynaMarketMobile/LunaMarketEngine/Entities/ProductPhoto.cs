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
        /// Товар.
        /// </summary>
        public Product Product
        {
            get
            {
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdProduct"] = (MySqlDbType.Int32, IdProduct)
                };

                return Core.GetObjectAsync<Product>(properties).Result;
            }
        }
    }
}
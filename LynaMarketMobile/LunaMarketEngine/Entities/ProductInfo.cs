using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Информация о товаре.
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Идентификатор цвета.
        /// </summary>
        public int IdColor { get; set; }

        /// <summary>
        /// Идентификатор материала.
        /// </summary>
        public int IdMaterial { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Цвет.
        /// </summary>
        public Color Color
        {
            get
            {
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdColor"] = (MySqlDbType.Int32, IdColor)
                };

                return Core.GetObjectAsync<Color>(properties).Result;
            }
        }

        /// <summary>
        /// Материал.
        /// </summary>
        public Material Material
        {
            get
            {
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdMaterial"] = (MySqlDbType.Int32, IdMaterial)
                };

                return Core.GetObjectAsync<Material>(properties).Result;
            }
        }

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

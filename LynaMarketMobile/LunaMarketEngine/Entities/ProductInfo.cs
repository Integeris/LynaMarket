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
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdColor", IdColor)
                };

                return Core.GetObjectAsync<Color>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Материал.
        /// </summary>
        public Material Material
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdMaterial", IdMaterial)
                };

                return Core.GetObjectAsync<Material>(staticProperties).Result;
            }
        }

        /// <summary>
        /// Товар.
        /// </summary>
        public Product Product
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdProduct", IdProduct)
                };

                return Core.GetObjectAsync<Product>(staticProperties).Result;
            }
        }
    }
}

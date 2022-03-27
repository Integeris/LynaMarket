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
        public int IdProduct { get; set; }
        public int IdColor { get; set; }
        public int IdMaterial { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        /// <summary>
        /// Цвет.
        /// </summary>
        public Color Color
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdColor"] = IdColor.ToString()
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
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdMaterial"] = IdMaterial.ToString()
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
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdProduct"] = IdProduct.ToString()
                };

                return Core.GetObjectAsync<Product>(properties).Result;
            }
        }
    }
}

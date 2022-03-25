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
        /// Цвета.
        /// </summary>
        public List<Color> Colors
        {
            get
            {
                return Core.GetColors().Result
                    .Where(color => color.IdColor == IdColor)
                    .ToList();
            }
        }

        /// <summary>
        /// Материалы.
        /// </summary>
        public List<Material> Materials
        {
            get
            {
                return Core.GetMaterials().Result
                    .Where(material => material.IdMaterial == IdMaterial)
                    .ToList();
            }
        }
    }
}

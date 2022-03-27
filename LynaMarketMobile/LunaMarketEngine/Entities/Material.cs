using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// материал.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Идентификатор материала.
        /// </summary>
        public int IdMaterial { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение информации о продуктах с этим материалом.
        /// </summary>
        public List<ProductInfo> GetProductInfos
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdMaterial"] = IdMaterial.ToString()
                };

                return Core.GetObjectsListAsync<ProductInfo>(properties).Result;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Цвет.
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdColor { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получение информации о продуктах с этим цветом.
        /// </summary>
        public List<ProductInfo> GetProductInfos
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdColor"] = IdColor.ToString()
                };

                return Core.GetObjectsListAsync<ProductInfo>(properties).Result;
            }
        }
    }
}

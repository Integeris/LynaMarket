using MySqlConnector;
using System.Collections.Generic;

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
                Dictionary<string, (MySqlDbType type, object value)> properties = new Dictionary<string, (MySqlDbType type, object value)>()
                {
                    ["IdColor"] = (MySqlDbType.Int32, IdColor)
                };

                return Core.GetObjectsListAsync<ProductInfo>(properties).Result;
            }
        }
    }
}

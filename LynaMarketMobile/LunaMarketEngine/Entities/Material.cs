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
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdMaterial", IdMaterial)
                };

                return Core.GetObjectsListAsync<ProductInfo>(staticProperties).Result;
            }
        }
    }
}

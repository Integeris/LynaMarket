using LunaMarketEngine.QueryConstructors.PropertiesTypes;
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
        /// Получение продуктов с этим цветом.
        /// </summary>
        public List<Product> GetProductы
        {
            get
            {
                List<StaticProperty> staticProperties = new List<StaticProperty>()
                {
                    new StaticProperty("IdColor", IdColor)
                };

                return Core.GetObjectsListAsync<Product>(staticProperties).Result;
            }
        }
    }
}

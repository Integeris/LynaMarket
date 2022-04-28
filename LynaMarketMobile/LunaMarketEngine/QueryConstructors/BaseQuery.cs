using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors
{
    /// <summary>
    /// Базовый шаблон запроса.
    /// </summary>
    internal abstract class BaseQuery
    {
        /// <summary>
        /// Назввание таблицы.
        /// </summary>
        protected string tableName;

        /// <summary>
        /// Список статичных свойств.
        /// </summary>
        protected List<StaticProperty> staticProperties;

        /// <summary>
        /// Название таблицы.
        /// </summary>
        public string TableName
        {
            get => tableName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "Название таблицы не должны быть пустым.");
                }

                tableName = value;
            }
        }

        /// <summary>
        /// Список статичных свойств.
        /// </summary>
        public List<StaticProperty> StaticProperties
        {
            get => staticProperties;
            set
            {
                if (value != null && value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                staticProperties = value;
            }
        }
    }
}

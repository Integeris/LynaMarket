using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Базовое свойство.
    /// </summary>
    public abstract class BaseProperty
    {
        /// <summary>
        /// Название столбца.
        /// </summary>
        protected string columnName;

        /// <summary>
        /// Тип свойства.
        /// </summary>
        protected MySqlDbType type;

        /// <summary>
        /// Навзвание столбца.
        /// </summary>
        public string ColumnName
        {
            get => columnName;
            set
            {
                columnName = value ?? throw new ArgumentNullException(nameof(value), "Название колонки не должно быть пустым.");
            }
        }

        /// <summary>
        /// Тип свойства.
        /// </summary>
        public MySqlDbType Type
        {
            get => type;
            set => type = value;
        }
    }
}

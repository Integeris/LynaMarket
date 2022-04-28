using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Точное свойство.
    /// </summary>
    public class StaticProperty : BaseProperty
    {
        /// <summary>
        /// Значение свойства.
        /// </summary>
        private object value;

        /// <summary>
        /// Название свойства.
        /// </summary>
        private string valueName;

        /// <summary>
        /// Навзвание столбца.
        /// </summary>
        public new string ColumnName
        {
            get => columnName;
            set
            {
                base.ColumnName = value;
                valueName = $"@{columnName}";
            }
        }

        /// <summary>
        /// Название свойства.
        /// </summary>
        public string ValueName
        {
            get => valueName;
        }

        /// <summary>
        /// Значение свойства.
        /// </summary>
        public object Value
        {
            get => value;
            set
            {
                this.value = value ?? throw new ArgumentNullException(nameof(value), "Значение свойства не может быть null.");
            }
        }

        /// <summary>
        /// Параметр свойства.
        /// </summary>
        public MySqlParameter Parameter
        {
            get
            {
                MySqlParameter mySqlParameter = new MySqlParameter(ValueName, type)
                {
                    Value = value
                };

                return mySqlParameter;
            }
        }

        /// <summary>
        /// Создание точного свойства.
        /// </summary>
        /// <param name="columnName">Название колонки.</param>
        /// <param name="value">Значение свойства.</param>
        public StaticProperty(string columnName, object value)
        {
            Value = value;
            ColumnName = columnName;

            this.type = new TypeSpecifier().GetMysqlType(value.GetType());
        }

        /// <summary>
        /// Возвращение текста sql.
        /// </summary>
        /// <returns>Текст sql.</returns>
        public override string ToString()
        {
            return $"`{columnName}` = {ValueName}";
        }
    }
}

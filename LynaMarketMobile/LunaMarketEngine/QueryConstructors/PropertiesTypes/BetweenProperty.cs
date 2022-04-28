using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Свойство с диапазоном.
    /// </summary>
    public class BetweenProperty : BaseProperty
    {
        /// <summary>
        /// Начальное значение.
        /// </summary>
        private object fromValue;

        /// <summary>
        /// Конечное значение.
        /// </summary>
        private object toValue;

        /// <summary>
        /// Название начального свойства.
        /// </summary>
        private string fromValueName;

        /// <summary>
        /// Название конечного свойства.
        /// </summary>
        private string toValueName;

        /// <summary>
        /// Начальное значение.
        /// </summary>
        public object FromValue
        {
            get => fromValue;
            set
            {
                fromValue = value ?? throw new ArgumentNullException(nameof(value), "Свойство не может быть null.");
            }
        }

        /// <summary>
        /// Конечное значение.
        /// </summary>
        public object ToValue
        {
            get => toValue;
            set
            {
                toValue = value ?? throw new ArgumentNullException(nameof(value), "Свойство не может быть null.");
            }
        }

        /// <summary>
        /// Название начального свойства.
        /// </summary>
        public string FromValueName
        {
            get => fromValueName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название свойства не может быть пустым.", nameof(value));
                }

                fromValueName = value;
            }
        }

        /// <summary>
        /// Название конечного свойства.
        /// </summary>
        public string ToValueName
        {
            get => toValueName;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название свойства не может быть пустым.", nameof(value));
                }

                toValueName = value;
            }
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                MySqlParameter mySqlParameter = new MySqlParameter(fromValueName, type)
                {
                    Value = fromValue
                };

                parameters.Add(mySqlParameter);

                mySqlParameter = new MySqlParameter(toValueName, type)
                {
                    Value = toValue
                };

                parameters.Add(mySqlParameter);
                return parameters;
            }
        }

        /// <summary>
        /// Создание нового свйства с диапазоном.
        /// </summary>
        /// <param name="columnName">Название свойства.</param>
        /// <param name="fromValue">Начальное значение.</param>
        /// <param name="toValue">Конечное значение.</param>
        public BetweenProperty(string columnName, object fromValue, object toValue)
        {
            ColumnName = columnName;
            FromValue = fromValue;
            ToValue = toValue;
        }

        /// <summary>
        /// Возвращение текста sql.
        /// </summary>
        /// <returns>Текст sql.</returns>
        public override string ToString()
        {
            return $"{columnName} BETWEEN {fromValueName} AND {toValueName}";
        }
    }
}

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
        /// Начальное значение.
        /// </summary>
        public object FromValue
        {
            get => fromValue;
            set
            {
                if (value == null && toValue == null)
                {
                    throw new ArgumentNullException(nameof(value), "Две границы не могут быть равны null.");
                }

                fromValue = value;
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
                if (value == null && fromValue == null)
                {
                    throw new ArgumentNullException(nameof(value), "Две границы не могут быть равны null.");
                }

                toValue = value;
            }
        }

        /// <summary>
        /// Название начального свойства.
        /// </summary>
        public string FromValueName
        {
            get => $"@from{columnName}";
        }

        /// <summary>
        /// Название конечного свойства.
        /// </summary>
        public string ToValueName
        {
            get => $"@to{columnName}";
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                MySqlParameter mySqlParameter;

                if (fromValue != null)
                {
                    mySqlParameter = new MySqlParameter(FromValueName, type)
                    {
                        Value = fromValue
                    };

                    parameters.Add(mySqlParameter);
                }

                if (toValue != null)
                {
                    mySqlParameter = new MySqlParameter(ToValueName, type)
                    {
                        Value = toValue
                    };

                    parameters.Add(mySqlParameter);
                }

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
            if (fromValue == null && toValue == null)
            {
                throw new ArgumentException("У свойства с диапазоном должна быть хотябы одна граница.");
            }

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
            string sqlText;

            if (fromValue != null && toValue != null)
            {
                sqlText = $"{columnName} BETWEEN {FromValueName} AND {ToValueName}";
            }
            else if (fromValue != null)
            {
                sqlText = $"{columnName} > {FromValueName}";
            }
            else
            {
                sqlText = $"{columnName} < {ToValueName}";
            }

            return sqlText;
        }
    }
}

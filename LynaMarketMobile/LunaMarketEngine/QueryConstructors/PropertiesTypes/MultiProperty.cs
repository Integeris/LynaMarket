using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Свойство с множеством значений.
    /// </summary>
    public class MultiProperty : BaseProperty
    {
        /// <summary>
        /// Список значений.
        /// </summary>
        private List<object> values;

        /// <summary>
        /// Названия значений.
        /// </summary>
        private readonly List<string> valuesNames = new List<string>();

        /// <summary>
        /// Навзвание столбца.
        /// </summary>
        public new string ColumnName
        {
            get => columnName;
            set
            {
                base.ColumnName = value;
                valuesNames.Clear();

                for (int i = 0; i < values.Count; i++)
                {
                    valuesNames.Add($"@{i}{columnName}");
                }
            }
        }

        /// <summary>
        /// Список значений.
        /// </summary>
        public List<object> Values
        {
            get => values;
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException(nameof(value), "Должно присутствовать хотябы одно значение.");
                }

                values = value;

                for (int i = 0; i < values.Count; i++)
                {
                    valuesNames.Add($"$${i}{columnName}");
                }
            }
        }

        /// <summary>
        /// Названия значений.
        /// </summary>
        public List<string> ValuesNames
        {
            get => valuesNames;
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get
            {
                List<MySqlParameter> result = new List<MySqlParameter>();

                for (int i = 0; i < values.Count; i++)
                {
                    MySqlParameter parameter = new MySqlParameter(valuesNames[i], type)
                    {
                        Value = values[i]
                    };

                    result.Add(parameter);
                }

                return result;
            }
        }

        /// <summary>
        /// Создание нового мульти свойства.
        /// </summary>
        /// <param name="columnName">Название столбца.</param>
        /// <param name="type">Тип столдбца.</param>
        /// <param name="values">Список значений.</param>
        public MultiProperty(string columnName, List<object> values)
        {
            Values = values;
            ColumnName = columnName;

            this.type = new TypeSpecifier().GetMysqlType(values[0].GetType());
        }

        /// <summary>
        /// Возврат sql-текста.
        /// </summary>
        /// <returns>sql-код.</returns>
        public override string ToString()
        {
            List<string> blocks = new List<string>();

            foreach (var item in valuesNames)
            {
                blocks.Add($"`{columnName}` = {item}");
            }

            return $"({String.Join(" OR ", blocks)})";
        }
    }
}

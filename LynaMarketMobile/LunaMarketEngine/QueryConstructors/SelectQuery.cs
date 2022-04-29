using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors
{
    /// <summary>
    /// Запрос на выборку.
    /// </summary>
    internal class SelectQuery : BaseQuery
    {
        /// <summary>
        /// Взять.
        /// </summary>
        private int take;

        /// <summary>
        /// Пропустить.
        /// </summary>
        private int skip;

        /// <summary>
        /// По возрастанию?
        /// </summary>
        private bool isASC;

        /// <summary>
        /// Свойства с диапазоном.
        /// </summary>
        private List<BetweenProperty> betweenProperties;

        /// <summary>
        /// Свойства с множеством значений.
        /// </summary>
        private List<MultiProperty> multiProperties;

        /// <summary>
        /// Список столбцов для сортировки.
        /// </summary>
        private List<string> sortColumns;

        /// <summary>
        /// Взять.
        /// </summary>
        public int Take
        {
            get => take;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Значение не может быть меньше или равно 0.");
                }

                take = value;
            }
        }

        /// <summary>
        /// Пропустить.
        /// </summary>
        public int Skip
        {
            get => skip;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Значение не может быть меньше 0.");
                }

                skip = value;
            }
        }

        /// <summary>
        /// По возрастанию?
        /// </summary>
        public bool IsASC
        {
            get => isASC;
            set => isASC = value;
        }

        /// <summary>
        /// Свойства с диапазоном.
        /// </summary>
        public List<BetweenProperty> BetweenProperties
        {
            get => betweenProperties;
            set
            {
                if (value != null && value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                betweenProperties = value;
            }
        }

        /// <summary>
        /// Свойства с множеством значений.
        /// </summary>
        public List<MultiProperty> MultiProperties
        {
            get => multiProperties;
            set
            {
                if (value != null && value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                multiProperties = value;
            }
        }

        /// <summary>
        /// Список столбцов для сортировки.
        /// </summary>
        public List<string> SortColumns
        {
            get => sortColumns;
            set
            {
                if (value != null && value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                sortColumns = value;
            }
        }

        /// <summary>
        /// Список параметров.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get
            {
                List<MySqlParameter> mySqlParameters = new List<MySqlParameter>();

                if (staticProperties != null)
                {
                    mySqlParameters.AddRange(staticProperties.Select(property => property.Parameter));
                }

                if (betweenProperties != null)
                {
                    foreach (var property in betweenProperties)
                    {
                        foreach (var item in property.Parameters)
                        {
                            mySqlParameters.Add(item);
                        }
                    }
                }

                if (multiProperties != null)
                {
                    foreach (var properties in multiProperties)
                    {
                        foreach (var item in properties.Parameters)
                        {
                            mySqlParameters.Add(item);
                        }
                    }
                }

                return mySqlParameters;
            }
        }

        /// <summary>
        /// Создание запроса на выборку.
        /// </summary>
        /// <param name="tableName">Название таблицы.</param>
        /// <param name="staticProperties">Статические свойства.</param>
        /// <param name="betweenProperties">Свойста с дмапозоном.</param>
        /// <param name="multiProperties">Свойства с множеством значений.</param>
        /// <param name="sortColumns">Список столбцов для сортировки.</param>
        /// <param name="take">Количество элементов для получения.</param>
        /// <param name="skip">Количество элеентов для пропуска.</param>
        /// <param name="isASC">Сортировка по возрастанию?</param>
        public SelectQuery(string tableName, List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default, 
            List<string> sortColumns = default, int take = Int32.MaxValue, int skip = 0, bool isASC = true)
        {
            TableName = tableName;
            StaticProperties = staticProperties;
            BetweenProperties = betweenProperties;
            MultiProperties = multiProperties;
            SortColumns = sortColumns;
            IsASC = isASC;
            this.take = take;
            this.skip = skip;
        }

        /// <summary>
        /// Получение sql-текста.
        /// </summary>
        /// <returns>Sql-текст.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT *");
            stringBuilder.AppendLine($"FROM `{tableName}`");

            if (staticProperties != null || betweenProperties != null || multiProperties != null)
            {
                stringBuilder.AppendLine($" WHERE ");
                List<String> stringBlocks = new List<string>();

                if (staticProperties != null)
                {
                    foreach (var item in staticProperties)
                    {
                        stringBlocks.Add(item.ToString());
                    }
                }

                if (betweenProperties != null)
                {
                    foreach (var item in betweenProperties)
                    {
                        stringBlocks.Add(item.ToString());
                    }
                }

                if (multiProperties != null)
                {
                    foreach (var item in multiProperties)
                    {
                        stringBlocks.Add(item.ToString());
                    }
                }

                stringBuilder.Append(String.Join(", ", stringBlocks));
            }

            if (sortColumns != null)
            {
                stringBuilder.AppendLine(" ORDER BY ");
                stringBuilder.Append(String.Join(", ", sortColumns));
                stringBuilder.Append($"{(isASC ? "ASC" : "DESC")}");
            }

            stringBuilder.AppendLine($" LIMIT {take} OFFSET {skip};");
            return stringBuilder.ToString();
        }
    }
}

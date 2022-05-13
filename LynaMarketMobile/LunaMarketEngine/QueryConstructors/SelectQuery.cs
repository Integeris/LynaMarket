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
        /// Свойство для расстояния Ливенштейна.
        /// </summary>
        private LivensgtainProperty livensgtainProperty;

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
        private List<SortingProperty> sortProperties;

        /// <summary>
        /// Свойство для расстояния Ливенштейна.
        /// </summary>
        public LivensgtainProperty LivensgtainProperty
        {
            get => livensgtainProperty;
            set => livensgtainProperty = value;
        }

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
        public List<SortingProperty> SortProperties
        {
            get => sortProperties;
            set
            {
                if (value != null && value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                sortProperties = value;
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
                    foreach (var property in multiProperties)
                    {
                        foreach (var item in property.Parameters)
                        {
                            mySqlParameters.Add(item);
                        }
                    }
                }

                if (livensgtainProperty != null)
                {
                    foreach (var item in livensgtainProperty.Parameters)
                    {
                        mySqlParameters.Add(item);
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
        /// <param name="sortingProperties">Список столбцов для сортировки.</param>
        /// <param name="livensgtainProperty">Свойство для расстояния Ливенштейна.</param>
        /// <param name="take">Количество элементов для получения.</param>
        /// <param name="skip">Количество элеентов для пропуска.</param>
        public SelectQuery(string tableName, List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default, 
            List<SortingProperty> sortingProperties = default, LivensgtainProperty livensgtainProperty = default, 
            int take = Int32.MaxValue, int skip = 0)
        {
            TableName = tableName;
            StaticProperties = staticProperties;
            BetweenProperties = betweenProperties;
            MultiProperties = multiProperties;
            SortProperties = sortingProperties;
            LivensgtainProperty = livensgtainProperty;
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
            stringBuilder.Append("SELECT *");

            if (livensgtainProperty != null)
            {
                stringBuilder.Append($", {livensgtainProperty}");
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"FROM `{tableName}`");

            if (staticProperties != null || betweenProperties != null || multiProperties != null || livensgtainProperty != null)
            {
                stringBuilder.Append($"WHERE ");
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

                stringBuilder.AppendLine(String.Join(" AND ", stringBlocks));
            }

            if (livensgtainProperty != null && livensgtainProperty.MaxStringLen != null)
            {
                stringBuilder.AppendLine($"HAVING {livensgtainProperty.GetHavingBlock()}");
            }

            if (livensgtainProperty != null || sortProperties != null)
            {
                stringBuilder.Append("ORDER BY ");

                if (livensgtainProperty != null)
                {
                    stringBuilder.Append($"{livensgtainProperty.ColumnName} ASC");
                }

                if (sortProperties != null)
                {
                    if (livensgtainProperty != null)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.AppendLine(String.Join(", ", sortProperties));
                }
            }

            stringBuilder.Append($"LIMIT {take} OFFSET {skip};");
            return stringBuilder.ToString();
        }
    }
}

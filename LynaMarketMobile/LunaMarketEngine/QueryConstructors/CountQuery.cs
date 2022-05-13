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
    /// Запрос на получение количесва элементов.
    /// </summary>
    internal class CountQuery : BaseQuery
    {
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
        /// Свойство для расстояния Ливенштейна.
        /// </summary>
        public LivensgtainProperty LivensgtainProperty
        {
            get => livensgtainProperty;
            set => livensgtainProperty = value;
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
        /// Создание запроса на получение количесва элементов.
        /// </summary>
        /// <param name="tableName">Название таблицы.</param>
        /// <param name="staticProperties">Статические свойства.</param>
        /// <param name="betweenProperties">Свойста с дмапозоном.</param>
        /// <param name="multiProperties">Свойства с множеством значений.</param>
        /// <param name="livensgtainProperty">Свойство для расстояния Ливенштейна.</param>
        public CountQuery(string tableName, List<StaticProperty> staticProperties = default,
            List<BetweenProperty> betweenProperties = default, List<MultiProperty> multiProperties = default,
            LivensgtainProperty livensgtainProperty = default)
        {
            TableName = tableName;
            StaticProperties = staticProperties;
            BetweenProperties = betweenProperties;
            MultiProperties = multiProperties;
            LivensgtainProperty = livensgtainProperty;
        }

        /// <summary>
        /// Получение sql-текста.
        /// </summary>
        /// <returns>Sql-текст.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SELECT COUNT(*)");
            stringBuilder.AppendLine($"FROM {tableName}");

            if (staticProperties != null || betweenProperties != null || multiProperties != null)
            {
                stringBuilder.Append($"WHERE ");
                List<String> stringBlocks = new List<string>();

                if (livensgtainProperty != null)
                {
                    stringBlocks.Add(livensgtainProperty.GetWhereBlock());
                }

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

            return stringBuilder.ToString();
        }
    }
}

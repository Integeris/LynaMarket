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
    /// Запрос на обновление объекта.
    /// </summary>
    internal class UpdateQuery : BaseQuery
    {
        /// <summary>
        /// Свойства для обновления объекта.
        /// </summary>
        private List<StaticProperty> setStaticProperties;

        /// <summary>
        /// Свойства с диапазоном.
        /// </summary>
        private List<BetweenProperty> betweenProperties;

        /// <summary>
        /// Свойства с множеством значений.
        /// </summary>
        private List<MultiProperty> multiProperties;

        /// <summary>
        /// Свойства для обновления объекта.
        /// </summary>
        public List<StaticProperty> SetStaticProperties
        {
            get => setStaticProperties;
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("Список не может быть пустым.", nameof(value));
                }

                setStaticProperties = value;
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

                if (setStaticProperties != null)
                {
                    mySqlParameters.AddRange(setStaticProperties.Select(property => property.Parameter));
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
        /// Создание запроса обновления данных.
        /// </summary>
        /// <param name="tableName">Название таблицы.</param>
        /// <param name="setStaticProperties">Свойства для обновления объекта.</param>
        /// <param name="staticProperties">Статические свойства.</param>
        /// <param name="betweenProperties">Свойста с дмапозоном.</param>
        /// <param name="multiProperties">Свойства с множеством значений.</param>
        public UpdateQuery(string tableName, List<StaticProperty> setStaticProperties, List<StaticProperty> staticProperties, 
            List<BetweenProperty> betweenProperties, List<MultiProperty> multiProperties)
        {
            TableName = tableName;
            SetStaticProperties = setStaticProperties;
            StaticProperties = staticProperties;
            BetweenProperties = betweenProperties;
            MultiProperties = multiProperties;
        }

        /// <summary>
        /// Получение sql-текста.
        /// </summary>
        /// <returns>Sql-текст.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> setProperties = setStaticProperties.Select(property => property.ToString()).ToList();

            stringBuilder.AppendLine($"UPDATE `{tableName}`");
            stringBuilder.AppendLine($"SET {String.Join(", ", setProperties)}");

            if (staticProperties != null || betweenProperties != null || multiProperties != null)
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

                stringBuilder.Append(String.Join(", ", stringBlocks));
            }

            stringBuilder.Append(";");
            return stringBuilder.ToString();
        }
    }
}

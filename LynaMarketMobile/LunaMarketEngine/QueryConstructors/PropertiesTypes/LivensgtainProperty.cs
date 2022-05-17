using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Свойство для описания расстояния Ливенштейна.
    /// </summary>
    public class LivensgtainProperty
    {
        /// <summary>
        /// Название колонки.
        /// </summary>
        private string columnName;

        /// <summary>
        /// Название свойства.
        /// </summary>
        private string propertyName;

        /// <summary>
        /// Шаблон поиска.
        /// </summary>
        private string template;

        /// <summary>
        /// Максимальное растояние для отдельного слова.
        /// </summary>
        private int maxWordLen;

        /// <summary>
        /// Максимальное растояние для всего предложения.
        /// </summary>
        private int? maxStringLen;

        /// <summary>
        /// Название колонки.
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
        /// Название свойства.
        /// </summary>
        public string PropertyName
        {
            get => propertyName;
            set
            {
                propertyName = value ?? throw new ArgumentNullException(nameof(value), "Название свойства не должно быть пустым.");
            }
        }

        /// <summary>
        /// Шаблон поиска.
        /// </summary>
        public string Template
        {
            get => template;
            set
            {
                template = value ?? throw new ArgumentNullException(nameof(value), "Название колонки не должно быть пустым.");
            }
        }

        /// <summary>
        /// Максимальное растояние для отдельного слова.
        /// </summary>
        public int MaxWordLen
        {
            get => maxWordLen;
            set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException("Степень совпадения слов не может быть меньше 1.");
                }

                maxWordLen = value;
            }
        }

        /// <summary>
        /// Максимальное растояние для всего предложения.
        /// </summary>
        public int? MaxStringLen
        {
            get => maxStringLen;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Степень совпадения предложения не может быть меньше 1.");
                }

                maxStringLen = value;
            }
        }

        /// <summary>
        /// Название параметра шаблона.
        /// </summary>
        public string TemplateName
        {
            get => $"@${nameof(Template)}{template.Trim().Replace(" ", "")}";
        }

        /// <summary>
        /// Название параметра максимального растояния для отдельного слова.
        /// </summary>
        public string MaxWordLenName
        {
            get => $"@${nameof(MaxWordLen)}";
        }

        /// <summary>
        /// Название параметра максимального растояния для всего предложения.
        /// </summary>
        public string MaxStringLenName
        {
            get => $"@${nameof(MaxStringLen)}";
        }

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter(TemplateName, MySqlDbType.String)
                    {
                        Value = template
                    },
                    new MySqlParameter(MaxWordLenName, MySqlDbType.Int32)
                    {
                        Value = maxWordLen
                    }
                };

                if (MaxStringLen != null)
                {
                    MySqlParameter mySqlParameter = new MySqlParameter(MaxStringLenName, MySqlDbType.Int32)
                    {
                        Value = maxStringLen
                    };

                    parameters.Add(mySqlParameter);
                }

                return parameters;
            }
        }

        /// <summary>
        /// Создание свойства для описания расстояния Ливенштейна.
        /// </summary>
        /// <param name="columnName">Название колонки.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <param name="template">Шаблон поиска.</param>
        /// <param name="maxWordLen">Максимальное растояние для отдельного слова.</param>
        /// <param name="maxStringLan">Максимальное растояние для всего предложения.</param>
        public LivensgtainProperty(string columnName, string propertyName, string template, int maxWordLen, int? maxStringLan = default)
        {
            ColumnName = columnName;
            PropertyName = propertyName;
            Template = template;
            MaxWordLen = maxWordLen;
            MaxStringLen = maxStringLan;
        }

        /// <summary>
        /// Получение блока Where для растояния Ливенштейна.
        /// </summary>
        /// <returns>Блок Where для растояния Ливенштейна.</returns>
        public string GetWhereBlock()
        {
            return $"GetLivenshteinLen({TemplateName}, {propertyName}, {MaxWordLenName}) <= {MaxStringLenName}";
        }

        /// <summary>
        /// Получение блока Having для растояния Ливенштейна.
        /// </summary>
        /// <returns>Блок Having для растояния Ливенштейна.</returns>
        public string GetHavingBlock()
        {
            return $"{columnName} <= {MaxStringLenName}";
        }

        /// <summary>
        /// Прлучение sql-кода.
        /// </summary>
        /// <returns>Sql-код.</returns>
        public override string ToString()
        {
            return $"GetLivenshteinLen({TemplateName}, {propertyName}, {MaxWordLenName}) AS {columnName}";
        }
    }
}

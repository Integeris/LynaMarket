using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors.PropertiesTypes
{
    /// <summary>
    /// Свойство для сортировки.
    /// </summary>
    public class SortingProperty : BaseProperty
    {
        /// <summary>
        /// По возрастанию?
        /// </summary>
        private bool isASC;

        /// <summary>
        /// По возрастанию?
        /// </summary>
        public bool IsASC
        {
            get => isASC;
            set => isASC = value;
        }

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string ParameterName
        {
            get => isASC ? "ASC" : "DESC";
        }

        /// <summary>
        /// Создание нового свойства для сортировки.
        /// </summary>
        /// <param name="columnName">Название колонки.</param>
        /// <param name="isASC">По возрастанию?</param>
        public SortingProperty(string columnName, bool isASC = true)
        {
            Type = new TypeSpecifier().GetMysqlType(isASC.GetType());
            ColumnName = columnName;
            this.isASC = isASC;
        }

        /// <summary>
        /// Возвращает Sql-текст.
        /// </summary>
        /// <returns>Sql-текст.</returns>
        public override string ToString()
        {
            return $"{columnName} {ParameterName}";
        }
    }
}

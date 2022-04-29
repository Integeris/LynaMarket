using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors
{
    internal class AddQuery : BaseQuery
    {
        /// <summary>
        /// Список параметров.
        /// </summary>
        public List<MySqlParameter> Parameters
        {
            get => staticProperties.Select(property => property.Parameter).ToList();
        }

        /// <summary>
        /// Создание нового запроса на добавление.
        /// </summary>
        /// <param name="tableName">Название таблицы.</param>
        /// <param name="staticProperties">Список параметров.</param>
        public AddQuery(string tableName, List<StaticProperty> staticProperties)
        {
            TableName = tableName;
            StaticProperties = staticProperties;
        }

        /// <summary>
        /// Получение sql-текста.
        /// </summary>
        /// <returns>Sql-текст.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<string> columnsNames = staticProperties.Select(property => property.ColumnName).ToList();
            List<string> valuesNames = staticProperties.Select(property => property.ValueName).ToList();

            stringBuilder.Append($"INSERT INTO `{tableName}` (");

            if (columnsNames.Count > 0)
            {
                stringBuilder.Append(String.Join(", ", columnsNames));
            }

            stringBuilder.AppendLine(")");
            stringBuilder.Append($"VALUES(");

            if (valuesNames.Count > 0)
            {
                stringBuilder.Append(String.Join(", ", valuesNames));
            }

            stringBuilder.AppendLine(");");
            stringBuilder.Append("SELECT @@IDENTITY;");

            return stringBuilder.ToString();
        }
    }
}

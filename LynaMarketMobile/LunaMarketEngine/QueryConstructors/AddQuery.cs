﻿using LunaMarketEngine.QueryConstructors.PropertiesTypes;
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

            stringBuilder.AppendLine($"INSERT INTO `{tableName}` (");
            stringBuilder.Append(")");
            stringBuilder.AppendLine($"VALUES(");
            stringBuilder.Append(");");
            stringBuilder.AppendLine("SELECT @@IDENTITY;");

            if (staticProperties != null)
            {
                stringBuilder.Insert(1, String.Join(", ", columnsNames));
                stringBuilder.Insert(4, String.Join(", ", valuesNames));
            }

            return stringBuilder.ToString();
        }
    }
}
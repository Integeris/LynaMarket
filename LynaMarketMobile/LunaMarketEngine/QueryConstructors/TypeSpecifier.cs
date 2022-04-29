using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.QueryConstructors
{
    /// <summary>
    /// Определитель типа.
    /// </summary>
    internal sealed class TypeSpecifier
    {
        /// <summary>
        /// Возвращает аналогичный тип Mysql
        /// </summary>
        /// <param name="type">Тип данных.</param>
        /// <returns>Тип базы данных Mysql.</returns>
        /// <exception cref="ArgumentException">Не найден аналогичный тип.</exception>
        public MySqlDbType GetMysqlType(Type type)
        {
            MySqlDbType mySqltype;
            
            switch (type.Name)
            {
                case nameof(String):
                    mySqltype = MySqlDbType.String;
                    break;
                case nameof(DateTime):
                    mySqltype = MySqlDbType.DateTime;
                    break;
                case nameof(Int32):
                    mySqltype = MySqlDbType.Int32;
                    break;
                case nameof(Decimal):
                    mySqltype = MySqlDbType.Decimal;
                    break;
                case nameof(Boolean):
                    mySqltype = MySqlDbType.Bool;
                    break;
                case "Byte[]":
                    mySqltype= MySqlDbType.LongBlob;
                    break;
                default:
                    throw new ArgumentException("Не обработанный тип данных.");
            }

            return mySqltype;
        }
    }
}

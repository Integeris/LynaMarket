using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Payment
{
    /// <summary>
    /// URL-параметр.
    /// </summary>
    public class UrlParameter
    {
        /// <summary>
        /// Название параметра.
        /// </summary>
        private string name;

        /// <summary>
        /// Значение параметра.
        /// </summary>
        private object value;

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = String.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException("Значение не может быть null или пустым.", nameof(Name)) : value;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public object Value
        {
            get => value;
            set => this.value = value ?? throw new ArgumentNullException("Значение не может быть null.", nameof(Value));
        }

        /// <summary>
        /// Создание URL-параметра.
        /// </summary>
        /// <param name="name">Название параметра.</param>
        /// <param name="value">Значение параметра.</param>
        public UrlParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Получение внешнего вида URL-параметра.
        /// </summary>
        /// <returns>Внешний вид URL-параметра.</returns>
        public override string ToString()
        {
            return $"{name}={value}";
        }
    }
}

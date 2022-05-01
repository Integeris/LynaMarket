using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Интерфейс для вывода вариантов фильтрации.
    /// </summary>
    internal class FilterView
    {
        /// <summary>
        /// Идентификатор объекта.
        /// </summary>
        public int IdObject { get; set; }

        /// <summary>
        /// Название папраметра.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Активен ли?
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}

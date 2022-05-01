using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Свойство для сортировки.
    /// </summary>
    internal class SortingPropertyView
    {
        /// <summary>
        /// Активно?.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Связанное свойсто.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// По возрастаню.
        /// </summary>
        public bool IsASC { get; set; }
    }
}

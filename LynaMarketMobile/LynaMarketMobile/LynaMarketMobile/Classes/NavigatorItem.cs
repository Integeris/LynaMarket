using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Элемент навигации.
    /// </summary>
    internal sealed class NavigatorItem
    {
        /// <summary>
        /// Цвет.
        /// </summary>
        public Color Color { get; set; }   

        /// <summary>
        /// Значение.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Создание нового элемента навигации.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="color">Цвет.</param>
        public NavigatorItem(int value, Color color)
        {
            Value = value;
            Color = color;
        }
    }
}

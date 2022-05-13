using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Интерфейс вывода товара.
    /// </summary>
    internal class ProductView
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Название цвета.
        /// </summary>
        public string ColorTitle { get; set; }

        /// <summary>
        /// Название материала.
        /// </summary>
        public string MatrialTitle { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Глубина.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Класс для вывода товара.
    /// </summary>
    internal sealed class ProductListView
    {
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int IdProduct { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public string Manufacturer { get; set; }

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

        /// <summary>
        /// Фотография.
        /// </summary>
        public ImageSource Photo { get; set; }

        /// <summary>
        /// Создание нового отображаемого товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="price">Цена.</param>
        /// <param name="amount">Количество.</param>
        /// <param name="description">Описание.</param>
        /// <param name="photo">Изображение товара.</param>
        public ProductListView(int idProduct, string title, string manufacturer, decimal price, int amount, string description, byte[] photo)
        {
            IdProduct = idProduct;
            Title = title;
            Manufacturer = manufacturer;
            Price = price;
            Amount = amount;
            Description = description;
            Photo = ImageSource.FromStream(() => new MemoryStream(photo));
        }
    }
}

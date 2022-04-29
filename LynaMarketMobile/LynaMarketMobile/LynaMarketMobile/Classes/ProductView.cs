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
    internal sealed class ProductView
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
        /// Фотография.
        /// </summary>
        public ImageSource Photo { get; set; }

        /// <summary>
        /// Создание нового отображаемого товара.
        /// </summary>
        /// <param name="idProduct">Идентификатор товара.</param>
        /// <param name="title">Название товара.</param>
        /// <param name="photo">Изображение товара.</param>
        public ProductView(int idProduct, string title, byte[] photo)
        {
            IdProduct = idProduct;
            Title = title;
            Photo = ImageSource.FromStream(() => new MemoryStream(photo));
        }
    }
}

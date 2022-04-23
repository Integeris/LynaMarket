using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Отображение новости.
    /// </summary>
    public class NewsView
    {
        /// <summary>
        /// Идентификатор новости.
        /// </summary>
        public int IdNews { get; set; }

        /// <summary>
        /// Изображение.
        /// </summary>
        public ImageSource Photo { get; set; }

        public NewsView(News news)
        {
            IdNews = news.IdNews;
            Photo = ImageSource.FromStream(() => new System.IO.MemoryStream(news.Photo));
        }
    }
}

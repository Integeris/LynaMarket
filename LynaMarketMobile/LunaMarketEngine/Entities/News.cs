using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Новость.
    /// </summary>
    public class News
    {
        /// <summary>
        /// Идентификатор новости.
        /// </summary>
        public int IdNews { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Дата публикации.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Изображение.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
    }
}

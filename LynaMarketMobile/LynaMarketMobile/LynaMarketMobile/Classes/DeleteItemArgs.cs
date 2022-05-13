using System;
using System.Collections.Generic;
using System.Text;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Параметры события удаления.
    /// </summary>
    public class DeleteItemArgs : EventArgs
    {
        /// <summary>
        /// Элемент.
        /// </summary>
        public object Item { get; private set; }

        /// <summary>
        /// Создание параметров при событии удаления.
        /// </summary>
        /// <param name="idItem">Элемент.</param>
        public DeleteItemArgs(object item)
        {
            Item = item;
        }
    }
}

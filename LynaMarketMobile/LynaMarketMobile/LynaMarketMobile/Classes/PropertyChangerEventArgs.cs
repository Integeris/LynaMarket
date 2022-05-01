using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Параметры события конца ввода текста в элемент управления PropertyChanger.
    /// </summary>
    public class PropertyChangerEventArgs : EventArgs
    {
        /// <summary>
        /// Поле ввода.
        /// </summary>
        public Entry Entry { get; private set; }

        /// <summary>
        /// Создание параметров события конца ввода текста в элемент управления PropertyChanger.
        /// </summary>
        /// <param name="entry">Поле ввода.</param>
        public PropertyChangerEventArgs(Entry entry)
        {
            Entry = entry;
        }
    }
}

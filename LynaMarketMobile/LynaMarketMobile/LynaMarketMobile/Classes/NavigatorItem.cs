using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Элемент навигации.
    /// </summary>
    internal sealed class NavigatorItem : INotifyPropertyChanged
    {
        private bool isEnabled = true;

        /// <summary>
        /// Цвет.
        /// </summary>
        public Color Color { get; set; }   

        /// <summary>
        /// Значение.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Акивность
        /// </summary>
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                isEnabled = value;
                NotifyPropertyChanged(nameof(IsEnabled));
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

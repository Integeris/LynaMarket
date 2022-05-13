using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Данные товара в корзине.
    /// </summary>
    public class BasketProductView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        private int idProduct;

        /// <summary>
        /// Название.
        /// </summary>
        private string title;

        /// <summary>
        /// Данные для изображения.
        /// </summary>
        private byte[] image;

        /// <summary>
        /// Количество.
        /// </summary>
        private int amount = 1;

        /// <summary>
        /// Максимальное количество.
        /// </summary>
        private int maxAmount;

        /// <summary>
        /// Цена одного товара.
        /// </summary>
        private decimal productPrice;

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public int IdProduct
        {
            get => idProduct;
            set => idProduct = value;
        }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Изображение.
        /// </summary>
        public ImageSource ImageSource
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(image));
            }
        }

        /// <summary>
        /// Данные для зображения.
        /// </summary>
        public byte[] Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount
        {
            get => amount;
            set
            {
                if (value > 0 && value <= MaxAmount)
                {
                    amount = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        /// <summary>
        /// Максимальное количество.
        /// </summary>
        public int MaxAmount
        {
            get => maxAmount;
            set
            {
                if (value > 0)
                {
                    if (value < amount)
                    {
                        amount = value;
                    }

                    maxAmount = value;
                }

                OnPropertyChanged(nameof(MaxAmount));
            }
        }

        /// <summary>
        /// Цена одного товара.
        /// </summary>
        public decimal ProductPrice
        {
            get => productPrice;
            set
            {
                productPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }

        /// <summary>
        /// Итоговая цена.
        /// </summary>
        public decimal Price
        {
            get => productPrice * amount;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

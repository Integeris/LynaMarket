using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.UserControls
{
    /// <summary>
    /// Навигатор по страницам каталога.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigator : ContentView
    {
        /// <summary>
        /// Текущая страница.
        /// </summary>
        private int currentPage = 1;

        /// <summary>
        /// Количество страниц.
        /// </summary>
        private int pageCount = 1;

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>
        private int itemsCountOnPage = 20;

        /// <summary>
        /// Количество элементов.
        /// </summary>
        private int itemsCount;

        /// <summary>
        /// Текущая страница.
        /// </summary>
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                if (value < 0 || value > pageCount)
                {
                    throw new ArgumentException("Недопустимое значение свойства.");
                }

                currentPage = value;
                SelectPage(this, new SelectPageEventArgs(value));
            }
        }

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int PageCount
        {
            get => pageCount;
        }

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>
        public int ItemsCountOnPage
        {
            get => itemsCountOnPage;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Недопустимое значение свойста.");
                }

                itemsCountOnPage = value;
                SetNewPropertyValues();
            }
        }

        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int ItemsCount
        {
            get => itemsCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Недопустимое значение свойства.");
                }

                itemsCount = value;
                SetNewPropertyValues();
            }
        }

        /// <summary>
        /// Методы события SelectPage.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Параметры события.</param>
        public delegate void SelectPageHandle(object sender, SelectPageEventArgs e);

        /// <summary>
        /// Событие выбора страницы.
        /// </summary>
        public event SelectPageHandle SelectPage;

        /// <summary>
        /// Новый навигатор по страницам каталога.
        /// </summary>
        public Navigator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действие при изменении свойств навигатора.
        /// </summary>
        private void SetNewPropertyValues()
        {
            pageCount = itemsCount / itemsCountOnPage + 1;

            if (currentPage > pageCount)
            {
                CurrentPage = pageCount;
            }
        }
    }
}
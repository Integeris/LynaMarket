using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int itemsCount = 1;

        /// <summary>
        /// Элементы навигации.
        /// </summary>
        private readonly ObservableCollection<NavigatorItem> items = new ObservableCollection<NavigatorItem>()
        {
            new NavigatorItem(1, Color.DarkGray)
        };

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
        /// Текущая страница.
        /// </summary>
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                if (value < 1 || value > pageCount)
                {
                    throw new ArgumentException("Недопустимое значение свойства.");
                }

                currentPage = value;
                MainCollectionView.ItemsSource = null;

                items[currentPage - 1].Color = Color.LightGray;
                items[value - 1].Color = Color.DarkGray;

                MainCollectionView.ItemsSource = items;
                MainCollectionView.ScrollTo(value - 1, default, ScrollToPosition.Center, false);
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
                else if (value == 0)
                {
                    itemsCount = 1;
                }
                else
                {
                    itemsCount = value;
                }

                SetNewPropertyValues();
            }
        }

        /// <summary>
        /// Новый навигатор по страницам каталога.
        /// </summary>
        public Navigator()
        {
            InitializeComponent();

            MainCollectionView.ItemsSource = items;
            SetNewPropertyValues();
        }

        /// <summary>
        /// Действие при изменении свойств навигатора.
        /// </summary>
        private void SetNewPropertyValues()
        {
            pageCount = (int)Math.Ceiling((double)itemsCount / itemsCountOnPage);

            if (items.Count < pageCount)
            {
                for (int i = items.Count + 1; i <= pageCount; i++)
                {
                    NavigatorItem item = new NavigatorItem(i, Color.LightGray);
                    items.Add(item);
                }
            }
            else if (items.Count > pageCount)
            {
                for (int i = items.Count; i > pageCount; i--)
                {
                    items.RemoveAt(i - 1);
                }
            }

            if (currentPage > pageCount)
            {
                CurrentPage = pageCount;
                SelectPage?.Invoke(this, new SelectPageEventArgs(currentPage));
            }
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            NavigatorItem navigatorItem = (NavigatorItem)clickedButton.BindingContext;
            int index = items.IndexOf(navigatorItem);
            int pageNumber = index + 1;

            if (currentPage != pageNumber)
            {
                CurrentPage = pageNumber;
                SelectPage?.Invoke(this, new SelectPageEventArgs(pageNumber));
            }
        }
    }
}
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
    /// Интерфейс для ввода свойств с диапазоном.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyChanger : ContentView
    {
        /// <summary>
        /// Методы при завершении ввода.
        /// </summary>
        /// <param name="sender"></param>
        public delegate void Completed(object sender, PropertyChangerEventArgs e);

        /// <summary>
        /// Событие окончания ввода тектса в поля ввода.
        /// </summary>
        public event Completed OnCompleted;

        /// <summary>
        /// Начальное значение.
        /// </summary>
        public string FromValue
        {
            get => FromValueEntry.Text;
            set
            {
                FromValueEntry.Text = value;
            }
        }

        /// <summary>
        /// Конечное значение.
        /// </summary>
        public string ToValue
        {
            get => ToValueEntry.Text;
            set
            {
                ToValueEntry.Text = value;
            }
        }

        /// <summary>
        /// Создание интерфейса для вода свойств с диапазоном.
        /// </summary>
        public PropertyChanger()
        {
            InitializeComponent();
        }

        private void EntryOnCompleted(object sender, EventArgs e)
        {
            OnCompleted?.Invoke(this, new PropertyChangerEventArgs((Entry)sender)); 
        }
    }
}
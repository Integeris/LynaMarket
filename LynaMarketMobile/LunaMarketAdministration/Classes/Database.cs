using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunaMarketAdministration.Classes
{
    internal class Database
    {
        /// <summary>
        /// Тип объекта.
        /// </summary>
        public static string Type = "";

        /// <summary>
        /// Код новости.
        /// </summary>
        public static int IdNews = 0;

        /// <summary>
        /// Код категории товаров.
        /// </summary>
        public static int IdCategory = 0;

        /// <summary>
        /// Код метода доставки.
        /// </summary>
        public static int IdDelivery = 0;

        /// <summary>
        /// Код материала товара.
        /// </summary>
        public static int IdMaterial = 0;

        /// <summary>
        /// Код цвета товара.
        /// </summary>
        public static int IdColor = 0;

        /// <summary>
        /// Код производителя товаров.
        /// </summary>
        public static int IdManufacturer = 0;

        /// <summary>
        /// Код заказчика.
        /// </summary>
        public static int IdCustomer = 0;

        /// <summary>
        /// Код товара.
        /// </summary>
        public static int IdProduct = 0;

        /// <summary>
        /// Код изображения товара.
        /// </summary>
        public static int IdproductPhoto = 0;

        /// <summary>
        /// Код адреса офиса.
        /// </summary>
        public static int IdOfficeAddress = 0;

        /// <summary>
        /// Код статуса заказа.
        /// </summary>
        public static int IdOrderStatus = 0;
        
        /// <summary>
        /// Код статуса оплаты.
        /// </summary>
        public static int IdPayStatus = 0;

        /// <summary>
        /// Код метода оплаты.
        /// </summary>
        public static int IdPayMethod = 0;

        /// <summary>
        /// Код заказа.
        /// </summary>
        public static int IdOrder = 0;

        /// <summary>
        /// Код заказанного товара.
        /// </summary>
        public static int IdOrderProduct = 0;

        /// <summary>
        /// Проверка заполнения текстовых полей.
        /// </summary>
        /// <param name="form">Название формы.</param>
        /// <returns></returns>
        public static int CheckingTextBoxes(Form form)
        {
            int i = 0;
            foreach (var control in form.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Проверка значений элементов NumericUpDown.
        /// </summary>
        /// <param name="form">Название формы.</param>
        /// <returns></returns>
        public static int CheckingNumericUpDowns(Form form)
        {
            int i = 0;
            foreach (var control in form.Controls.OfType<NumericUpDown>())
            {
                if (control.Value == 0)
                {
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Очистка текстовых полей.
        /// </summary>
        /// <param name="form">Название формы.</param>
        public static void СlearingTextBoxes(Form form)
        {
            foreach (var control in form.Controls.OfType<TextBox>())
            {
                control.Clear();
            }
        }

        /// <summary>
        /// Обнуление всех элементов NumericUpDown.
        /// </summary>
        /// <param name="form">Название формы.</param>
        public static void СlearingNumericUpDowns(Form form)
        {
            foreach (var control in form.Controls.OfType<NumericUpDown>())
            {
                control.Value = 0;
            }
        }

        /// <summary>
        /// Вывод стандартного изображения в PictureBox.
        /// </summary>
        /// <param name="pictureBox">Название элемента PictureBox</param>
        public static void СlearingPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = Properties.Resources.no;
        }

        /// <summary>
        /// Обнуление всех полей класса Database.
        /// </summary>
        public static void ClearFields()
        {
            IdNews = 0;
            IdCategory = 0;
            IdDelivery = 0;
            IdMaterial = 0;
            IdColor = 0;
            IdManufacturer = 0;
            IdCustomer = 0;
            IdProduct = 0;
            IdproductPhoto = 0;
        }

        /// <summary>
        /// Очистка элементов формы.
        /// </summary>
        /// <param name="listView">Элемент управления ListView.</param>
        /// <param name="list">Список.</param>
        /// <param name="imageList">Список изображений.</param>
        public static void ClearLists(ListView listView, List<string> list, ImageList imageList)
        { 
            listView.Items.Clear();
            imageList.Images.Clear();
            list.Clear();
        }
    }
}

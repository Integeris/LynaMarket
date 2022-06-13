using LunaMarketEngine;
using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunaMarketAdministration.Classes
{
    public static class DataGridManager
    { 
        /// <summary>
        /// Создание столбцов.
        /// </summary>
        /// <param name="dataGridView">Элемент управления DataGridView расположенный на форме.</param>
        /// <param name="type">Тип получаемой информации.</param>
        public static async void CreateColumns(DataGridView dataGridView, string type)
        {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;

            switch (type)
            {
                case "News":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdNews";
                    dataGridView.Columns[0].Name = "IdNewsColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Заголовок";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[2].HeaderText = "Дата";
                    dataGridView.Columns[2].DataPropertyName = "Date";
                    dataGridView.Columns[2].Name = "DateColumn";

                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.HeaderText = "Изображение";
                    imageColumn.DataPropertyName = "Photo";
                    imageColumn.Name = "PhotoColumn";
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dataGridView.Columns.Add(imageColumn);

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[4].HeaderText = "Описание";
                    dataGridView.Columns[4].DataPropertyName = "Description";
                    dataGridView.Columns[4].Name = "DescriptionColumn";

                    List<News> news = await Core.GetNewsAsync();
                    dataGridView.DataSource = news;
                    break;
                case "Category":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdProductCategory";
                    dataGridView.Columns[0].Name = "IdProductCategoryColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<ProductCategory> categories = await Core.GetProductCategoriesAsync();
                    dataGridView.DataSource = categories;
                    break;
                case "Delivery":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdDeliveryType";
                    dataGridView.Columns[0].Name = "IdDeliveryTypeColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<DeliveryType> delivery = await Core.GetDeliveryTypesAsync();
                    dataGridView.DataSource = delivery;
                    break;
                case "Material":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdMaterial";
                    dataGridView.Columns[0].Name = "IdMaterialColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<Material> materials = await Core.GetMaterialsAsync();
                    dataGridView.DataSource = materials;
                    break;
                case "Color":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdColor";
                    dataGridView.Columns[0].Name = "IdColorColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<Color> colors = await Core.GetColorsAsync();
                    dataGridView.DataSource = colors;
                    break;
                case "Manufacturer":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdManufacturer";
                    dataGridView.Columns[0].Name = "IdManufacturerColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<Manufacturer> manufacturers = await Core.GetManufacturersAsync();
                    dataGridView.DataSource = manufacturers;
                    break;
                case "Customer":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdCustomer";
                    dataGridView.Columns[0].Name = "IdCustomerColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Логин";
                    dataGridView.Columns[1].DataPropertyName = "Login";
                    dataGridView.Columns[1].Name = "LoginColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[2].HeaderText = "Пароль";
                    dataGridView.Columns[2].DataPropertyName = "Password";
                    dataGridView.Columns[2].Name = "PasswordColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[3].HeaderText = "Имя";
                    dataGridView.Columns[3].DataPropertyName = "FirstName";
                    dataGridView.Columns[3].Name = "FirstNameColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[4].HeaderText = "Фамилия";
                    dataGridView.Columns[4].DataPropertyName = "SecondName";
                    dataGridView.Columns[4].Name = "SecondNameColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[5].HeaderText = "E-mail";
                    dataGridView.Columns[5].DataPropertyName = "Email";
                    dataGridView.Columns[5].Name = "EmailColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[6].HeaderText = "Телефон";
                    dataGridView.Columns[6].DataPropertyName = "Phone";
                    dataGridView.Columns[6].Name = "PhoneColumn";
                    List<Customer> customers = await Core.GetCustomersAsync();
                    dataGridView.DataSource = customers;
                    break;
                case "Product":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdProduct";
                    dataGridView.Columns[0].Name = "IdProductColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Производитель";
                    dataGridView.Columns[1].DataPropertyName = "IdManufacturer";
                    dataGridView.Columns[1].Name = "IdManufacturerColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[2].HeaderText = "Категория";
                    dataGridView.Columns[2].DataPropertyName = "IdProductCategory";
                    dataGridView.Columns[2].Name = "IdProductCategoryColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[3].HeaderText = "Наименование";
                    dataGridView.Columns[3].DataPropertyName = "Title";
                    dataGridView.Columns[3].Name = "TitleColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[4].HeaderText = "Цвет";
                    dataGridView.Columns[4].DataPropertyName = "IdColor";
                    dataGridView.Columns[4].Name = "IdColorColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[5].HeaderText = "Материал";
                    dataGridView.Columns[5].DataPropertyName = "IdMaterial";
                    dataGridView.Columns[5].Name = "IdMaterialColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[6].HeaderText = "Стоимость";
                    dataGridView.Columns[6].DataPropertyName = "Price";
                    dataGridView.Columns[6].Name = "PriceColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[7].HeaderText = "Количество";
                    dataGridView.Columns[7].DataPropertyName = "Amount";
                    dataGridView.Columns[7].Name = "AmountColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[8].HeaderText = "Высота";
                    dataGridView.Columns[8].DataPropertyName = "Height";
                    dataGridView.Columns[8].Name = "HeightColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[9].HeaderText = "Ширина";
                    dataGridView.Columns[9].DataPropertyName = "Width";
                    dataGridView.Columns[9].Name = "WidthColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[10].HeaderText = "Глубина";
                    dataGridView.Columns[10].DataPropertyName = "Depth";
                    dataGridView.Columns[10].Name = "DepthColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[11].HeaderText = "Описание";
                    dataGridView.Columns[11].DataPropertyName = "Description";
                    dataGridView.Columns[11].Name = "DescriptionColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[12].HeaderText = "Удален";
                    dataGridView.Columns[12].DataPropertyName = "Deleted";
                    dataGridView.Columns[12].Name = "DeletedColumn";

                    List<Product> products = await Core.GetProductsAsync();
                    dataGridView.DataSource = products;
                    break;
                case "Office":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdOfficeAddress";
                    dataGridView.Columns[0].Name = "IdOfficeAddressColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<OfficeAddress> office = await Core.GetOfficeAddressesAsync();
                    dataGridView.DataSource = office;
                    break;
                case "OrderStatus":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdOrderStatus";
                    dataGridView.Columns[0].Name = "IdOrderStatusColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<OrderStatus> orderStatuses = await Core.GetOrderStatusesAsync();
                    dataGridView.DataSource = orderStatuses;
                    break;
                case "PayMethod":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdPaymentMethod";
                    dataGridView.Columns[0].Name = "IdPaymentMethod";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<PaymentMethod> paymentMethods = await Core.GetPaymentMethodsAsync();
                    dataGridView.DataSource = paymentMethods;
                    break;
                case "PayStatus":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdPayStatus";
                    dataGridView.Columns[0].Name = "IdPayStatus";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Название";
                    dataGridView.Columns[1].DataPropertyName = "Title";
                    dataGridView.Columns[1].Name = "TitleColumn";

                    List<PayStatus> payStatuses = await Core.GetPayStatusesAsync();
                    dataGridView.DataSource = payStatuses;
                    break;
                case "Order":
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = "Код";
                    dataGridView.Columns[0].DataPropertyName = "IdOrder";
                    dataGridView.Columns[0].Name = "IdOrderColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[1].HeaderText = "Заказчик";
                    dataGridView.Columns[1].DataPropertyName = "IdCustomer";
                    dataGridView.Columns[1].Name = "IdCustomerColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[2].HeaderText = "Статус заказа";
                    dataGridView.Columns[2].DataPropertyName = "IdOrderStatus";
                    dataGridView.Columns[2].Name = "IdOrderStatusColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[3].HeaderText = "Метод оплаты";
                    dataGridView.Columns[3].DataPropertyName = "IdPaymentMethod";
                    dataGridView.Columns[3].Name = "IdPaymentMethodColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[4].HeaderText = "Статус оплаты";
                    dataGridView.Columns[4].DataPropertyName = "IdPayStatus";
                    dataGridView.Columns[4].Name = "IdPayStatusColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[5].HeaderText = "Способ доставки";
                    dataGridView.Columns[5].DataPropertyName = "IdDeliveryType";
                    dataGridView.Columns[5].Name = "IdDeliveryTypeColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[6].HeaderText = "Дата";
                    dataGridView.Columns[6].DataPropertyName = "Date";
                    dataGridView.Columns[6].Name = "DateColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[7].HeaderText = "Адрес";
                    dataGridView.Columns[7].DataPropertyName = "Address";
                    dataGridView.Columns[7].Name = "AddressColumn";

                    List<Order> orders = await Core.GetOrdersAsync();
                    dataGridView.DataSource = orders;
                    break;
                default:
                    break;
            }
        }
    }
}

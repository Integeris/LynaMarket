using LunaMarketAdministration.Classes;
using LunaMarketEngine;
using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = LunaMarketEngine.Entities.Color;

namespace LunaMarketAdministration.Forms
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private async void SelectFormOnLoad(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            switch (Database.Type)
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
                    dataGridView.Columns[1].HeaderText = "Код производителя";
                    dataGridView.Columns[1].DataPropertyName = "IdManufacturer";
                    dataGridView.Columns[1].Name = "IdManufacturerColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[2].HeaderText = "Код категории";
                    dataGridView.Columns[2].DataPropertyName = "IdProductCategory";
                    dataGridView.Columns[2].Name = "IdProductCategoryColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[3].HeaderText = "Наименование";
                    dataGridView.Columns[3].DataPropertyName = "Title";
                    dataGridView.Columns[3].Name = "TitleColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[4].HeaderText = "Высота";
                    dataGridView.Columns[4].DataPropertyName = "Height";
                    dataGridView.Columns[4].Name = "HeightColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[5].HeaderText = "Ширина";
                    dataGridView.Columns[5].DataPropertyName = "Width";
                    dataGridView.Columns[5].Name = "WidthColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[6].HeaderText = "Глубина";
                    dataGridView.Columns[6].DataPropertyName = "Depth";
                    dataGridView.Columns[6].Name = "DepthColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[7].HeaderText = "Описание";
                    dataGridView.Columns[7].DataPropertyName = "Description";
                    dataGridView.Columns[7].Name = "DescriptionColumn";

                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[8].HeaderText = "Удален";
                    dataGridView.Columns[8].DataPropertyName = "Deleted";
                    dataGridView.Columns[8].Name = "DeletedColumn";

                    List<Product> products = await Core.GetProductsAsync();
                    dataGridView.DataSource = products;
                    break;
                default:
                    break;
            }
        }

        private void SelectButtonOnClick(object sender, EventArgs e)
        {
            switch (Database.Type)
            {
                case "News":
                    Database.IdNews = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Category":
                    Database.IdCategory = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Delivery":
                    Database.IdDelivery = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Material":
                    Database.IdMaterial = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Color":
                    Database.IdColor = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Manufacturer":
                    Database.IdManufacturer = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Customer":
                    Database.IdCustomer = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}

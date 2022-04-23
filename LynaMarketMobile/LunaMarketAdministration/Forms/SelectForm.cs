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

                    //dataGridView.Columns.Add(new DataGridViewImageColumn());
                    //dataGridView.Columns[3].HeaderText = "Изображение";
                    //dataGridView.Columns[3].DataPropertyName = "Photo";
                    //dataGridView.Columns[3].Name = "PhotoColumn";
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
                default:
                    break;
            }
        }
    }
}

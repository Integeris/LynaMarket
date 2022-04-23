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
    public partial class ProductCategoryForm : Form
    {
        public ProductCategoryForm()
        {
            InitializeComponent();
        }

        private void ActionCategoryComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionCategoryComboBox.SelectedIndex)
            {
                case 1:
                    actionCategoryButton.Text = "Изменить";
                    selectCategoryButton.Visible = true;
                    break;
                case 2:
                    actionCategoryButton.Text = "Удалить";
                    selectCategoryButton.Visible = true;
                    break;
                default:
                    actionCategoryButton.Text = "Добавить";
                    selectCategoryButton.Visible = false;
                    break;
            }
        }

        private void ProductCategoryFormOnLoad(object sender, EventArgs e)
        {
            actionCategoryComboBox.SelectedIndex = 0;
        }

        private void ActionCategoryButtonOnClick(object sender, EventArgs e)
        {
            switch (actionCategoryComboBox.SelectedIndex)
            {
                case 0:
                    Core.AddProductCategory(categoryTextBox.Text);
                    break;
                case 1:
                    Core.UpdateProductCategory(Database.IdCategory, categoryTextBox.Text);
                    break;
                case 2:
                    Core.DeleteProductCategory(Database.IdCategory);
                    break;
            }
        }

        private async void SelectCategoryButtonOnClick(object sender, EventArgs e)
        {
            Database.Type = "Category";
            SelectForm selectForm = new SelectForm();
            selectForm.ShowDialog();
            ProductCategory category = await Core.GetProductCategoryAsync(Database.IdCategory);
            categoryTextBox.Text = category.Title;
        }
    }
}

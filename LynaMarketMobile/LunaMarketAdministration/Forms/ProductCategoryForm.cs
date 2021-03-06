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
                    Database.СlearingTextBoxes(this);
                    break;
                case 2:
                    actionCategoryButton.Text = "Удалить";
                    selectCategoryButton.Visible = true;
                    Database.СlearingTextBoxes(this);
                    break;
                default:
                    actionCategoryButton.Text = "Добавить";
                    selectCategoryButton.Visible = false;
                    Database.СlearingTextBoxes(this);
                    break;
            }
        }

        private void ProductCategoryFormOnLoad(object sender, EventArgs e)
        {
            actionCategoryComboBox.SelectedIndex = 0;
        }

        private async void ActionCategoryButtonOnClick(object sender, EventArgs e)
        {
            switch (actionCategoryComboBox.SelectedIndex)
            {
                case 0:
                    if (Database.CheckingTextBoxes(this) == 0)
                    {
                        await Core.AddProductCategory(categoryTextBox.Text);
                        categoryTextBox.Text = null;
                        Database.IdCategory = 0;
                        Database.СlearingTextBoxes(this);
                    }
                    else
                    {
                        MessageBox.Show("Вы сударь мудак?");
                    }
                    break;
                case 1:
                    if ((Database.IdCategory != 0) || (Database.CheckingTextBoxes(this) == 0))
                    {
                        Core.UpdateProductCategory(Database.IdCategory, categoryTextBox.Text);
                        categoryTextBox = null;
                        Database.IdCategory = 0;
                        Database.СlearingTextBoxes(this);
                    }
                    else
                    {
                        MessageBox.Show("Вы сударь мудак?");
                    }
                    break;
                case 2:
                    if (Database.IdCategory != 0)
                    {
                        Core.DeleteProductCategory(Database.IdCategory);
                        categoryTextBox = null;
                        Database.IdCategory = 0;
                        Database.СlearingTextBoxes(this);
                    }
                    else
                    {
                        MessageBox.Show("Вы сударь мудак?");
                    }
                    break;
            }
        }

        private async void SelectCategoryButtonOnClick(object sender, EventArgs e)
        {
            Database.Type = "Category";
            SelectForm selectForm = new SelectForm();
            selectForm.ShowDialog();
            if (Database.IdCategory != 0)
            {
                ProductCategory category = await Core.GetProductCategoryAsync(Database.IdCategory);
                categoryTextBox.Text = category.Title;
            }
        }
    }
}

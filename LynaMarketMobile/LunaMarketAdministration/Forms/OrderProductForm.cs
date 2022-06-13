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
    public partial class OrderProductForm : Form
    {
        public OrderProductForm()
        {
            InitializeComponent();
        }

        private void ActionComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    actionOrderProductButton.Text = "Добавить";
                    selectButton.Visible = false;
                    idOrderLabel.Visible = false;
                    updateProductButton.Visible = false;
                    idOrderLabel.Text = null;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    Database.СlearingNumericUpDowns(this);
                    CreateColumns();
                    break;
                case 1:
                    actionOrderProductButton.Text = "Изменить";
                    selectButton.Visible = true;
                    updateProductButton.Visible = true;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    Database.СlearingNumericUpDowns(this);
                    idOrderLabel.Text = null;
                    CreateColumns();
                    break;
                case 2:
                    actionOrderProductButton.Text = "Удалить";
                    selectButton.Visible = true;
                    updateProductButton.Visible = false;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    Database.СlearingNumericUpDowns(this);
                    idOrderLabel.Text = null;
                    CreateColumns();
                    break;
            }
        }

        /// <summary>
        /// Метод для создания столбцов в DataGridView.
        /// </summary>
        private void CreateColumns()
        {
            productDGV.DataSource = null;
            productDGV.Rows.Clear();
            productDGV.Refresh();
            productDGV.AutoGenerateColumns = false;

            productDGV.AutoGenerateColumns = false;
            productDGV.Columns.Add(new DataGridViewTextBoxColumn());
            productDGV.Columns[0].HeaderText = "Код заказа";
            productDGV.Columns[0].DataPropertyName = "IdOrder";
            productDGV.Columns[0].Name = "IdOrderColumn";
            productDGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            productDGV.Columns.Add(new DataGridViewTextBoxColumn());
            productDGV.Columns[1].HeaderText = "Код товара";
            productDGV.Columns[1].DataPropertyName = "IdProduct";
            productDGV.Columns[1].Name = "IdProductColumn";
            productDGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            productDGV.Columns.Add(new DataGridViewTextBoxColumn());
            productDGV.Columns[2].HeaderText = "Стоимость";
            productDGV.Columns[2].DataPropertyName = "Price";
            productDGV.Columns[2].Name = "PriceColumn";
            productDGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            productDGV.Columns.Add(new DataGridViewTextBoxColumn());
            productDGV.Columns[3].HeaderText = "Количество";
            productDGV.Columns[3].DataPropertyName = "Amount";
            productDGV.Columns[3].Name = "AmountColumn";
            productDGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void OrderProductFormOnLoad(object sender, EventArgs e)
        {
            actionComboBox.SelectedIndex = 0;
            CreateColumns();
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.СlearingTextBoxes(this);
                Database.ClearFields();
                Database.Type = "Order";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdOrder != 0)
                {
                    Order order = await Core.GetOrderAsync(Database.IdOrder);
                    idOrderLabel.Visible = true;
                    idOrderLabel.Text = $"Заказ № {order.IdOrder}";

                    List<OrderProduct> orderProducts = await order.GetOrderProductsAsync();
                    productDGV.DataSource = orderProducts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectProductButtonOnClick(object sender, EventArgs e)
        {
            if (Database.IdOrder != 0)
            {
                Database.IdOrderProduct = (int)productDGV.CurrentRow.Cells[1].Value;

                Product product = await Core.GetProductAsync(Database.IdOrderProduct);
                productTextBox.Text = product.Title;

                priceNUD.Value = Convert.ToDecimal(productDGV.CurrentRow.Cells[2].Value);
                amountNUD.Value = (int)(productDGV.CurrentRow.Cells[3].Value);
            }
            else
            {
                MessageBox.Show("Вы ничего не выбрали!");
            }
        }

        private async void ActionOrderProductButtonOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddOrderProduct(Database.IdOrder, Database.IdProduct, priceNUD.Value, (int)amountNUD.Value);
                    if (id != 0)
                    {
                        Database.СlearingTextBoxes(this);
                        Database.СlearingNumericUpDowns(this);
                        Database.ClearFields();
                        MessageBox.Show("Запись добавлена.");
                        idOrderLabel.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdOrder != 0)
                    {
                        if (Database.IdProduct != 0)
                        {
                            Core.UpdateOrderProduct(Database.IdOrder, Database.IdProduct, priceNUD.Value, (int)amountNUD.Value);
                            Database.СlearingTextBoxes(this);
                            Database.СlearingNumericUpDowns(this);
                            Database.ClearFields();
                            idOrderLabel.Text = null;
                        }
                        else if (Database.IdOrderProduct != 0)
                        {
                            Core.UpdateOrderProduct(Database.IdOrder, Database.IdOrderProduct, priceNUD.Value, (int)amountNUD.Value);
                            Database.СlearingTextBoxes(this);
                            Database.СlearingNumericUpDowns(this);
                            Database.ClearFields();
                            idOrderLabel.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Все плохо!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdOrder != 0)
                    {
                        Core.DeleteOrderProduct(Database.IdOrder, Database.IdOrderProduct);
                        Database.СlearingTextBoxes(this);
                        Database.СlearingNumericUpDowns(this);
                        Database.ClearFields();
                        idOrderLabel.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }

        private async void UpdateProductButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdProduct = 0;
                Database.Type = "Product";

                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdProduct != 0)
                {
                    Product product = await Core.GetProductAsync(Database.IdProduct);
                    productTextBox.Text = product.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

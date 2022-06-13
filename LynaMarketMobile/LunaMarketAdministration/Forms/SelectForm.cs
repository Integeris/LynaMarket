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

        private void SelectFormOnLoad(object sender, EventArgs e)
        {
            DataGridManager.CreateColumns(dataGridView, Database.Type);
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
                case "Product":
                    Database.IdProduct = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Office":
                    Database.IdOfficeAddress = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "OrderStatus":
                    Database.IdOrderStatus = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "PayMethod":
                    Database.IdPayMethod = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "PayStatus":
                    Database.IdPayStatus = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case "Order":
                    Database.IdOrder = (int)dataGridView.CurrentRow.Cells[0].Value;
                    selectButton.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}

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
    public partial class DeliveryForm : Form
    {
        public DeliveryForm()
        {
            InitializeComponent();
        }

        private void ActionDeliveryComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionDeliveryComboBox.SelectedIndex)
            {
                case 0:
                    actionDeliveryButton.Text = "Добавить";
                    selectButton.Visible = false;
                    break;
                case 1:
                    actionDeliveryButton.Text = "Изменить";
                    selectButton.Visible = true;
                    break;
                case 2:
                    actionDeliveryButton.Text = "Удалить";
                    selectButton.Visible = true;
                    break;
            }
        }

        private void DeliveryFormOnLoad(object sender, EventArgs e)
        {
            actionDeliveryComboBox.SelectedIndex = 0;
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdDelivery = 0;
                Database.Type = "Delivery";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdDelivery != 0)
                {
                    DeliveryType delivery = await Core.GetDeliveryTypeAsync(Database.IdDelivery);
                    deliveryTextBox.Text = delivery.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionDeliveryButtonOnClick(object sender, EventArgs e)
        {
            switch (actionDeliveryComboBox.SelectedIndex)
            {
                case 0:
                    await Core.AddProductCategory(deliveryTextBox.Text);
                    deliveryTextBox.Text = null;
                    Database.IdDelivery = 0;
                    MessageBox.Show("Вы ничего не выбрали");
                    break;
                case 1:
                    if (Database.IdDelivery != 0)
                    {
                        Core.UpdateProductCategory(Database.IdDelivery, deliveryTextBox.Text);
                        deliveryTextBox.Text = null;
                        Database.IdDelivery = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdDelivery != 0)
                    {
                        Core.DeleteProductCategory(Database.IdDelivery);
                        deliveryTextBox.Text = null;
                        Database.IdDelivery = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }
    }
}

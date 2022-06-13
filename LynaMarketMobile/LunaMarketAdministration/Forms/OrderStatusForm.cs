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
    public partial class OrderStatusForm : Form
    {
        public OrderStatusForm()
        {
            InitializeComponent();
        }

        private void actionStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionStatusComboBox.SelectedIndex)
            {
                case 0:
                    actionStatusButton.Text = "Добавить";
                    selectButton.Visible = false;
                    statusTextBox.Text = null;
                    Database.IdOrderStatus = 0;
                    break;
                case 1:
                    actionStatusButton.Text = "Изменить";
                    selectButton.Visible = true;
                    statusTextBox.Text = null;
                    Database.IdOrderStatus = 0;
                    break;
                case 2:
                    actionStatusButton.Text = "Удалить";
                    selectButton.Visible = true;
                    statusTextBox.Text = null;
                    Database.IdOrderStatus = 0;
                    break;
            }
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdOrderStatus = 0;
                Database.Type = "OrderStatus";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdOrderStatus != 0)
                {
                    OrderStatus orderStatus = await Core.GetOrderStatusAsync(Database.IdOrderStatus);
                    statusTextBox.Text = orderStatus.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionStatusButtonOnClick(object sender, EventArgs e)
        {
            switch (actionStatusComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddOrderStatus(statusTextBox.Text);
                    if (id != 0)
                    {
                        statusTextBox.Text = null;
                        Database.IdOrderStatus = 0;
                        MessageBox.Show("Запись добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdOrderStatus != 0)
                    {
                        Core.UpdateOrderStatus(Database.IdOrderStatus, statusTextBox.Text);
                        statusTextBox.Text = null;
                        Database.IdOrderStatus = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdOrderStatus != 0)
                    {
                        Core.DeleteOrderStatus(Database.IdOrderStatus);
                        statusTextBox.Text = null;
                        Database.IdOrderStatus = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }

        private void OrderStatusFormOnLoad(object sender, EventArgs e)
        {
            actionStatusComboBox.SelectedIndex = 0;
        }
    }
}

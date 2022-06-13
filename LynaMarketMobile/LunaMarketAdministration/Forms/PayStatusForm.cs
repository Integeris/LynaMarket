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
    public partial class PayStatusForm : Form
    {
        public PayStatusForm()
        {
            InitializeComponent();
        }

        private void ActionPayStatusComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionPayStatusComboBox.SelectedIndex)
            {
                case 0:
                    actionPayStatusButton.Text = "Добавить";
                    selectButton.Visible = false;
                    payStatusTextBox.Text = null;
                    Database.IdPayStatus = 0;
                    break;
                case 1:
                    actionPayStatusButton.Text = "Изменить";
                    selectButton.Visible = true;
                    payStatusTextBox.Text = null;
                    Database.IdPayStatus = 0;
                    break;
                case 2:
                    actionPayStatusButton.Text = "Удалить";
                    selectButton.Visible = true;
                    payStatusTextBox.Text = null;
                    Database.IdPayStatus = 0;
                    break;
            }
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdPayMethod = 0;
                Database.Type = "PayStatus";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdPayStatus != 0)
                {
                    PayStatus payStatus = await Core.GetPayStatusAsync(Database.IdPayStatus);
                    payStatusTextBox.Text = payStatus.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionPayStatusButtonOnClick(object sender, EventArgs e)
        {
            switch (actionPayStatusComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddPayStatus(payStatusTextBox.Text);
                    if (id != 0)
                    {
                        payStatusTextBox.Text = null;
                        Database.IdPayStatus = 0;
                        MessageBox.Show("Запись добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdPayStatus != 0)
                    {
                        Core.UpdatePayStatus(Database.IdPayStatus, payStatusTextBox.Text);
                        payStatusTextBox.Text = null;
                        Database.IdPayStatus = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdPayStatus != 0)
                    {
                        Core.DeletePayStatus(Database.IdPayStatus);
                        payStatusTextBox.Text = null;
                        Database.IdPayMethod = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }

        private void PayStatusForm_Load(object sender, EventArgs e)
        {
            actionPayStatusComboBox.SelectedIndex = 0;
        }
    }
}

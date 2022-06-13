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
    public partial class PayMethodForm : Form
    {
        public PayMethodForm()
        {
            InitializeComponent();
        }

        private void PayMethodFormOnLoad(object sender, EventArgs e) 
        {
            actionPayMethodComboBox.SelectedIndex = 0;
        }

        private void ActionPayMethodComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionPayMethodComboBox.SelectedIndex)
            {
                case 0:
                    actionPayMethodButton.Text = "Добавить";
                    selectButton.Visible = false;
                    payMethodTextBox.Text = null;
                    Database.IdPayMethod = 0;
                    break;
                case 1:
                    actionPayMethodButton.Text = "Изменить";
                    selectButton.Visible = true;
                    payMethodTextBox.Text = null;
                    Database.IdPayMethod = 0;
                    break;
                case 2:
                    actionPayMethodButton.Text = "Удалить";
                    selectButton.Visible = true;
                    payMethodTextBox.Text = null;
                    Database.IdPayMethod = 0;
                    break;
            }
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdPayMethod = 0;
                Database.Type = "PayMethod";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdPayMethod != 0)
                {
                    PaymentMethod paymentMethod = await Core.GetPaymentMethodAsync(Database.IdPayMethod);
                    payMethodTextBox.Text = paymentMethod.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionPayMethodButtonOnClick(object sender, EventArgs e)
        {
            switch (actionPayMethodComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddPaymentMethod(payMethodTextBox.Text);
                    if (id != 0)
                    {
                        payMethodTextBox.Text = null;
                        Database.IdPayMethod = 0;
                        MessageBox.Show("Запись добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdPayMethod != 0)
                    {
                        Core.UpdatePaymentMethod(Database.IdPayMethod, payMethodTextBox.Text);
                        payMethodTextBox.Text = null;
                        Database.IdPayMethod = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdPayMethod != 0)
                    {
                        Core.DeletePaymentMethod(Database.IdPayMethod);
                        payMethodTextBox.Text = null;
                        Database.IdPayMethod = 0;
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

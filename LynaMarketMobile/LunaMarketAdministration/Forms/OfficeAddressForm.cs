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
    public partial class OfficeAddressForm : Form
    {
        public OfficeAddressForm()
        {
            InitializeComponent();
        }

        private void ActionComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    actionButton.Text = "Добавить";
                    selectButton.Visible = false;
                    break;
                case 1:
                    actionButton.Text = "Изменить";
                    selectButton.Visible = true;
                    break;
                case 2:
                    actionButton.Text = "Удалить";
                    selectButton.Visible = true;
                    break;
            }
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdOfficeAddress = 0;
                Database.Type = "Office";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdOfficeAddress != 0)
                {
                    OfficeAddress officeAddress = await Core.GetOfficeAddressAsync(Database.IdOfficeAddress);
                    addressTextBox.Text = officeAddress.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionButtonOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddOfficeAddress(addressTextBox.Text);
                    if (id != 0)
                    {
                        addressTextBox.Text = null;
                        Database.IdOfficeAddress = 0;
                        MessageBox.Show("Запись добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdOfficeAddress != 0)
                    {
                        Core.UpdateOfficeAddress(Database.IdOfficeAddress, addressTextBox.Text);
                        addressTextBox.Text = null;
                        Database.IdOfficeAddress = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdOfficeAddress != 0)
                    {
                        Core.DeleteOfficeAddress(Database.IdOfficeAddress);
                        addressTextBox.Text = null;
                        Database.IdOfficeAddress = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }

        private void OfficeAddressFormOnLoad(object sender, EventArgs e)
        {
            actionComboBox.SelectedIndex = 0;
        }
    }
}

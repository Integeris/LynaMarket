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
    public partial class ManufacturerForm : Form
    {
        public ManufacturerForm()
        {
            InitializeComponent();
        }

        private void ActionManufacturerComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionManufacturerComboBox.SelectedIndex)
            {
                case 1:
                    actionManufacturerButton.Text = "Изменить";
                    selectButton.Visible = true;
                    break;
                case 2:
                    actionManufacturerButton.Text = "Удалить";
                    selectButton.Visible = true;
                    break;
                default:
                    actionManufacturerButton.Text = "Добавить";
                    selectButton.Visible = false;
                    break;
            }
        }

        private void ManufacturerFormOnLoad(object sender, EventArgs e)
        {
            actionManufacturerComboBox.SelectedIndex = 0;
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdManufacturer = 0;
                Database.Type = "Manufacturer";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdManufacturer != 0)
                {
                    Manufacturer manufacturer = await Core.GetManufacturerAnsyc(Database.IdManufacturer);
                    manufacturerTextBox.Text = manufacturer.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionManufacturerButtonOnClick(object sender, EventArgs e)
        {
            switch (actionManufacturerComboBox.SelectedIndex)
            {
                case 0:
                    await Core.AddManufacturer(manufacturerTextBox.Text);
                    manufacturerTextBox = null;
                    Database.IdManufacturer = 0;
                    break;
                case 1:
                    if (Database.IdManufacturer != 0)
                    {
                        Core.UpdateManufacturer(Database.IdManufacturer, manufacturerTextBox.Text);
                        manufacturerTextBox = null;
                        Database.IdManufacturer = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdManufacturer != 0)
                    {
                        Core.DeleteManufacturer(Database.IdManufacturer);
                        manufacturerTextBox = null;
                        Database.IdManufacturer = 0;
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

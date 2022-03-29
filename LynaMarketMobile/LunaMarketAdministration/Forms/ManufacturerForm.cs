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
                    break;
                case 2:
                    actionManufacturerButton.Text = "Удалить";
                    break;
                default:
                    actionManufacturerButton.Text = "Добавить";
                    break;
            }
        }

        private void ManufacturerFormOnLoad(object sender, EventArgs e)
        {
            actionManufacturerComboBox.SelectedIndex = 0;
        }
    }
}

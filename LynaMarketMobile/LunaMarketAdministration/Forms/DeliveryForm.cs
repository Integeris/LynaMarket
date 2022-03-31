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
                    break;
                case 1:
                    actionDeliveryButton.Text = "Изменить";
                    break;
                case 2:
                    actionDeliveryButton.Text = "Удалить";
                    break;
            }
        }

        private void DeliveryFormOnLoad(object sender, EventArgs e)
        {
            actionDeliveryComboBox.SelectedIndex = 0;
        }
    }
}

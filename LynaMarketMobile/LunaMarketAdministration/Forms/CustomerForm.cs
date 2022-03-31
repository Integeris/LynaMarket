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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void ActionDeliveryComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionDeliveryComboBox.SelectedIndex)
            {
                case 0:
                    actionCustomerButton.Text = "Добавить";
                    selectCustomerButton.Visible = false;
                    break;
                case 1:
                    actionCustomerButton.Text = "Изменить";
                    selectCustomerButton.Visible = true;
                    break;
                case 2:
                    actionCustomerButton.Text = "Удалить";
                    selectCustomerButton.Visible = true;
                    break;
            }
        }

        private void CustomerFormOnLoad(object sender, EventArgs e)
        {
            actionDeliveryComboBox.SelectedIndex = 0;
        }
    }
}

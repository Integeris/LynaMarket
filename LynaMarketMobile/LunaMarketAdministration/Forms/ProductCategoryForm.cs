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
    public partial class ProductCategoryForm : Form
    {
        public ProductCategoryForm()
        {
            InitializeComponent();
        }

        private void ActionCategoryComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionCategoryComboBox.SelectedIndex)
            {
                case 1:
                    actionCategoryButton.Text = "Изменить";
                    break;
                case 2:
                    actionCategoryButton.Text = "Удалить";
                    break;
                default:
                    actionCategoryButton.Text = "Добавить";
                    break;
            }
        }

        private void ProductCategoryFormOnLoad(object sender, EventArgs e)
        {
            actionCategoryComboBox.SelectedIndex = 0;
        }
    }
}

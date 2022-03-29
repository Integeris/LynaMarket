using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunaMarketAdministration.Forms
{
    public partial class LookForm : Form
    {
        public LookForm()
        {
            InitializeComponent();
        }

        private void LookFormOnLoad(object sender, EventArgs e)
        {
            actionColorComboBox.SelectedIndex = 0;
            actionMaterialComboBox.SelectedIndex = 0;
        }

        private void ActionMaterialComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionMaterialComboBox.SelectedIndex)
            {
                case 0:
                    actionMaterialButton.Text = "Добавить";
                    break;
                case 1:
                    actionMaterialButton.Text = "Изменить";
                    break;
                case 2:
                    actionMaterialButton.Text = "Удалить";
                    break;
            }
        }

        private void ActionColorComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionColorComboBox.SelectedIndex)
            {
                case 0:
                    actionColorButton.Text = "Добавить";
                    break;
                case 1:
                    actionColorButton.Text = "Изменить";
                    break;
                case 2:
                    actionColorButton.Text = "Удалить";
                    break;
            }
        }

        private void ActionMaterialButtonOnClick(object sender, EventArgs e)
        {
            string pattern = @"^[А-ЯЁ][а-яё(?:\.| )]+[а-яё(?:\.|)]+$";

            if (Regex.IsMatch(materialTextBox.Text, pattern) && (materialTextBox.TextLength < 50))
            {
                MessageBox.Show("Все ОК!");
            }
            else
            {
                MessageBox.Show("Бан!");
            }
        }

        private void ActionColorButtonOnClick(object sender, EventArgs e)
        {
            string pattern = @"^[А-ЯЁ][а-яё (?:\-|)]+$";
            if (Regex.IsMatch(colorTextBox.Text, pattern) && (colorTextBox.TextLength < 50))
            {
                MessageBox.Show("Все ОК!");
            }
            else
            {
                MessageBox.Show("Бан!");
            }
        }
    }
}

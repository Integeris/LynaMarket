using LunaMarketEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunaMarketAdministration.Forms
{
    public partial class NewsForm : Form
    {
        public NewsForm()
        {
            InitializeComponent();
        }

        private string imagePath = "";

        private void NewsFormOnLoad(object sender, EventArgs e)
        {
            actionComboBox.SelectedIndex = 0;
            imagePictureBox.Image = Properties.Resources.no;
        }

        private void SelectImageButtonOnClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите изображение";
            ofd.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ...";

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            imagePath = ofd.FileName;
            imagePictureBox.Image = Image.FromFile(imagePath);
        }

        private void ActionComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 1:
                    editButton.Text = "Изменить";
                    break;
                case 2:
                    editButton.Text = "Удалить";
                    break;
                default:
                    editButton.Text = "Добавить";
                    break;
            }
        }

        private void EditButtonOnClick(object sender, EventArgs e)
        {
            string patternTitle = @"^[А-ЯЁ][а-яё]+$";
            if (Regex.IsMatch(titleTextBox.Text, patternTitle) && (titleTextBox.TextLength < 50))
            {
                MessageBox.Show("Все ОК!Title");
            }
            else
            {
                MessageBox.Show("Бан!Title");
            }

            string patternDescription = @"^[А-ЯЁ][а-яё\.\-\,\!\?]+$";
            if (Regex.IsMatch(descriptionTextBox.Text, patternDescription) && (descriptionTextBox.TextLength < 50))
            {
                MessageBox.Show("Все ОК!");
            }
            else
            {
                MessageBox.Show("Бан!");
            }

            if (actionComboBox.SelectedIndex == 0)
            {
                //byte[] image = File.ReadAllBytes(imagePath);
                Core.AddNews(titleTextBox.Text, DateTime.Now, File.ReadAllBytes(imagePath), descriptionTextBox.Text);
            }
        }
    }
}

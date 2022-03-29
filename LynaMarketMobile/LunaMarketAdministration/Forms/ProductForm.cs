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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductFormOnLoad(object sender, EventArgs e)
        {
            actionComboBox.SelectedIndex = 0;
            productPictureBox.Image = Properties.Resources.no;
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

        private void SelectImageButtonOnClick(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите изображение";
            ofd.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ...";

            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            imagePath = ofd.FileName;
            productPictureBox.Image = Image.FromFile(imagePath);
        }
    }
}

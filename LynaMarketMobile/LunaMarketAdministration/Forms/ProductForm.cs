using LunaMarketAdministration.Classes;
using LunaMarketEngine;
using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private string imagePath = null;

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
                    selectProductButton.Visible = true;
                    Database.СlearingPictureBox(productPictureBox);
                    Database.CheckingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    imagePath = null;
                    break;
                case 2:
                    editButton.Text = "Удалить";
                    selectProductButton.Visible = true;
                    Database.СlearingPictureBox(productPictureBox);
                    Database.CheckingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    imagePath = null;
                    break;
                default:
                    editButton.Text = "Добавить";
                    selectProductButton.Visible = false;
                    Database.СlearingPictureBox(productPictureBox);
                    Database.CheckingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    imagePath = null;
                    break;
            }
        }

        private void SelectImageButtonOnClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите изображение";
            ofd.Filter = "Image Files| *.jpg; *.jpeg; *.png; *.tif; ...";

            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                imagePath = ofd.FileName;
                productPictureBox.Image = Image.FromFile(imagePath);
            }
        }

        private async void SelectProductButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.Idproduct = 0;
                Database.Type = "Product";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.Idproduct != 0)
                {
                    Product product = await Core.GetProductAsync(Database.Idproduct);

                    //using (MemoryStream memoryStream = new MemoryStream(pr.Photo))
                    //{
                    //    productPictureBox.Image = Bitmap.FromStream(memoryStream);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

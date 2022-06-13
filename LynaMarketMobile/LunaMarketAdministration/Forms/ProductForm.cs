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
            //selectProductButton.Visible = true;
            //ListViewItem listViewItem = new ListViewItem(new );
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
                Database.IdProduct = 0;
                Database.Type = "Product";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdProduct != 0)
                {
                    Product product = await Core.GetProductAsync(Database.IdProduct);

                    Manufacturer manufacturer = await Core.GetManufacturerAnsyc(product.IdManufacturer);
                    manufacturerTextBox.Text = manufacturer.Title;

                    ProductCategory category = await Core.GetProductCategoryAsync(product.IdProductCategory);
                    categoryTextBox.Text = category.Title;

                    LunaMarketEngine.Entities.Color color = await Core.GetColorAsync(product.IdColor);
                    colorTextBox.Text = color.Title;

                    Material material = await Core.GetMaterialAsync(product.IdMaterial); 
                    materialTextBox.Text = material.Title;

                    titleTextBox.Text = product.Title;
                    heightNumericUpDown.Value = product.Height;
                    widthNumericUpDown.Value = product.Width;
                    depthNumericUpDown.Value = product.Depth;
                    priceNumericUpDown.Value = product.Price;
                    amontNumericUpDown.Value = product.Amount;
                    descriptionTextBox.Text = product.Description;

                    //int count = product.ProductPhotos.Count;
                    //MessageBox.Show(count.ToString());

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

        private async void EditButtonOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    if ((Database.CheckingTextBoxes(this) == 0) && (Database.CheckingNumericUpDowns(this) == 0) && (imagePath != ""))
                    {
                        int idProduct = await Core.AddProduct(Database.IdManufacturer, Database.IdCategory,
                            Database.IdColor, Database.IdMaterial, titleTextBox.Text, priceNumericUpDown.Value, (int)amontNumericUpDown.Value,(int)heightNumericUpDown.Value,
                            (int)widthNumericUpDown.Value, (int)depthNumericUpDown.Value, descriptionTextBox.Text);
                        int idPhoto = await Core.AddProductPhoto(idProduct, File.ReadAllBytes(imagePath));
                        string text = ((idProduct != 0) && (idPhoto != 0)) ? "Товар добавлен." : "Товар не добавлен.";
                        MessageBox.Show(text);
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                    break;
                case 1:
                    //Core.UpdateProduct(Database.IdProduct, );

                    break;
                case 2:
                    break;
            }
        }

        private async void SelectManufacturerButtonOnClick(object sender, EventArgs e)
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

        private async void SelectCategoryButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdCategory = 0;
                Database.Type = "Category";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdCategory != 0)
                {
                    ProductCategory productCategory = await Core.GetProductCategoryAsync(Database.IdCategory);
                    categoryTextBox.Text = productCategory.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectColorButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdColor = 0;
                Database.Type = "Color";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdColor != 0)
                {
                    LunaMarketEngine.Entities.Color color = await Core.GetColorAsync(Database.IdColor);
                    colorTextBox.Text = color.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectMaterialButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdMaterial = 0;
                Database.Type = "Material";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdMaterial != 0)
                {
                    Material material = await Core.GetMaterialAsync(Database.IdMaterial);
                    materialTextBox.Text = material.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

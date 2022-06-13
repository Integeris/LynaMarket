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

        /// <summary>
        /// Путь к изображению.
        /// </summary>
        private string imagePath = null;

        /// <summary>
        /// Идентификатор изображения.
        /// </summary>
        private int idPhoto = 0;

        Product product = null;

        ImageList imageList = new ImageList();

        List<ProductPhoto> productPhotos = new List<ProductPhoto>();

        List<string> imagesPath = new List<string>();

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
                    Database.ClearFields();
                    Database.СlearingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    Database.СlearingPictureBox(productPictureBox);
                    imagePath = null;
                    listView.Items.Clear();
                    imageList.Images.Clear();
                    imagesPath.Clear();
                    break;
                case 2:
                    editButton.Text = "Удалить";
                    selectProductButton.Visible = true;
                    Database.ClearFields();
                    Database.СlearingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    Database.СlearingPictureBox(productPictureBox);
                    imagePath = null;
                    listView.Items.Clear();
                    imageList.Images.Clear();
                    imagesPath.Clear();
                    break;
                default:
                    editButton.Text = "Добавить";
                    selectProductButton.Visible = false;
                    Database.ClearFields();
                    Database.СlearingTextBoxes(this);
                    Database.СlearingNumericUpDowns(this);
                    Database.СlearingPictureBox(productPictureBox);
                    imagePath = null;
                    listView.Items.Clear();
                    imageList.Images.Clear();
                    imagesPath.Clear();
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

                listView.Clear();
                imageList.Images.Clear();

                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdProduct != 0)
                {
                    product = await Core.GetProductAsync(Database.IdProduct);

                    Database.IdManufacturer = product.IdManufacturer;
                    Database.IdMaterial = product.IdMaterial;
                    Database.IdColor = product.IdColor;
                    Database.IdCategory = product.IdProductCategory;

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

                    productPhotos = await product.GetProductPhotoAsync();

                    imageList.ImageSize = new Size(50, 50);
                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[i].Image))
                        {
                            imageList.Images.Add(Bitmap.FromStream(memoryStream));
                        }
                    }
                    listView.LargeImageList = imageList;

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        listView.Items.Add("", i);
                    }
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
                        int idProduct = await Core.AddProduct(Database.IdManufacturer, Database.IdCategory, Database.IdColor, Database.IdMaterial,
                            titleTextBox.Text, priceNumericUpDown.Value, (int)amontNumericUpDown.Value, (int)heightNumericUpDown.Value,
                            (int)widthNumericUpDown.Value, (int)depthNumericUpDown.Value, descriptionTextBox.Text);

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            await Core.AddProductPhoto(idProduct, File.ReadAllBytes(imagesPath[i]));
                        }

                        string text = (idProduct != 0) ? "Товар добавлен." : "Товар не добавлен.";
                        MessageBox.Show(text);
                        Database.ClearFields();
                        Database.СlearingTextBoxes(this);
                        Database.СlearingNumericUpDowns(this);
                        Database.СlearingPictureBox(productPictureBox);
                        Database.ClearLists(listView, imagesPath, imageList);
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                    break;
                case 1:
                    if ((Database.CheckingTextBoxes(this) == 0) && (Database.CheckingNumericUpDowns(this) == 0) && (Database.IdProduct != 0))
                    {
                        Core.UpdateProduct(Database.IdProduct, Database.IdManufacturer, Database.IdCategory, Database.IdColor,
                            Database.IdMaterial, titleTextBox.Text, priceNumericUpDown.Value, (int)amontNumericUpDown.Value,
                            (int)heightNumericUpDown.Value, (int)widthNumericUpDown.Value, (int)depthNumericUpDown.Value,
                            descriptionTextBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                    break;
                case 2:
                    Core.DeleteProduct(Database.IdProduct);
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

        private void ListViewOnItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    if ((imagesPath != null) && (listView.SelectedIndices.Count != 0))
                    {
                        idPhoto = listView.SelectedIndices[0];
                        productPictureBox.Image = Image.FromFile(imagesPath[idPhoto]);
                    }
                    else
                    {
                        idPhoto = 0;
                        productPictureBox.Image = Properties.Resources.no;
                    }
                    break;
                case 1:
                    if ((listView.SelectedIndices.Count != 0) && (productPhotos.Count != 0))
                    {
                        idPhoto = listView.SelectedIndices[0];

                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[idPhoto].Image))
                        {
                            productPictureBox.Image = Bitmap.FromStream(memoryStream);
                        }
                    }
                    else
                    {
                        idPhoto = 0;
                        productPictureBox.Image = Properties.Resources.no;
                    }
                    break;
                case 2:
                    if ((listView.SelectedIndices.Count != 0) && (productPhotos.Count != 0))
                    {
                        idPhoto = listView.SelectedIndices[0];

                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[idPhoto].Image))
                        {
                            productPictureBox.Image = Bitmap.FromStream(memoryStream);
                        }
                    }
                    else
                    {
                        Database.IdproductPhoto = 0;
                        productPictureBox.Image = Properties.Resources.no;
                    }
                    break;
            }
        }

        private async void AddPictureBoxOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    imageList.ImageSize = new Size(50, 50);
                    if (Database.IdProduct == 0)
                    {
                        listView.Clear();
                        imageList.Images.Clear();
                        imagesPath.Add(imagePath);

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            imageList.Images.Add(Image.FromFile(imagesPath[i]));
                        }
                        listView.LargeImageList = imageList;

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            listView.Items.Add(i.ToString(), i);
                        }
                    }
                    break;
                case 1:
                    await Core.AddProductPhoto(product.IdProduct, File.ReadAllBytes(imagePath));
                    listView.Clear();
                    imageList.Images.Clear();

                    product = await Core.GetProductAsync(product.IdProduct);
                    productPhotos = await product.GetProductPhotoAsync();

                    imageList.ImageSize = new Size(50, 50);
                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[i].Image))
                        {
                            imageList.Images.Add(Bitmap.FromStream(memoryStream));
                        }
                    }
                    listView.LargeImageList = imageList;

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        listView.Items.Add(i.ToString(), i);
                    }
                    break;
                case 2:
                    break;
            }
        }

        private async void DeletePictureBoxOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    imageList.ImageSize = new Size(50, 50);
                    if (Database.IdProduct == 0)
                    {
                        listView.Clear();
                        imageList.Images.Clear();
                        imagesPath.RemoveAt(idPhoto);

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            imageList.Images.Add(Image.FromFile(imagesPath[i]));
                        }
                        listView.LargeImageList = imageList;

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            listView.Items.Add(i.ToString(), i);
                        }
                    }
                    break;
                case 1:
                    Core.DeleteProductPhoto(productPhotos[idPhoto].IdProductPhoto);

                    listView.Clear();
                    imageList.Images.Clear();

                    product = await Core.GetProductAsync(product.IdProduct);
                    productPhotos = await product.GetProductPhotoAsync();

                    imageList.ImageSize = new Size(50, 50);

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[i].Image))
                        {
                            imageList.Images.Add(Bitmap.FromStream(memoryStream));
                        }
                    }

                    listView.LargeImageList = imageList;

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        listView.Items.Add(i.ToString(), i);
                    }
                    break;
                case 2:
                    break;
            }
        }

        private async void UpdatePictureBoxOnClick(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    imageList.ImageSize = new Size(50, 50);
                    if (Database.IdProduct == 0)
                    {
                        listView.Clear();
                        imageList.Images.Clear();
                        imagesPath[idPhoto] = imagePath;

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            imageList.Images.Add(Image.FromFile(imagesPath[i]));
                        }
                        listView.LargeImageList = imageList;

                        for (int i = 0; i < imagesPath.Count; i++)
                        {
                            listView.Items.Add(i.ToString(), i);
                        }
                    }
                    break;
                case 1:
                    Core.UpdateProductPhoto(productPhotos[idPhoto].IdProductPhoto, Database.IdProduct, File.ReadAllBytes(imagePath));

                    listView.Clear();
                    imageList.Images.Clear();

                    product = await Core.GetProductAsync(product.IdProduct);
                    productPhotos = await product.GetProductPhotoAsync();

                    imageList.ImageSize = new Size(50, 50);

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(productPhotos[i].Image))
                        {
                            imageList.Images.Add(Bitmap.FromStream(memoryStream));
                        }
                    }

                    listView.LargeImageList = imageList;

                    for (int i = 0; i < productPhotos.Count; i++)
                    {
                        listView.Items.Add(i.ToString(), i);
                    }
                    break;
                case 2:
                    listView.Clear();
                    imageList.Images.Clear();
                    break;
            }
        }
    }
}

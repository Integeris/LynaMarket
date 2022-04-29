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
        private int code = 0;

        private void NewsFormOnLoad(object sender, EventArgs e)
        {
            actionComboBox.SelectedIndex = 0;
            imagePictureBox.Image = Properties.Resources.no;
        }

        private void SelectImageButtonOnClick(object sender, EventArgs e)
        {
            code = 1;
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
                imagePictureBox.Image = Image.FromFile(imagePath);
            }
        }

        private void ActionComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionComboBox.SelectedIndex)
            {
                case 1:
                    imagePath = "";
                    editButton.Text = "Изменить";
                    selectNewsButton.Visible = true;
                    break;
                case 2:
                    imagePath = "";
                    editButton.Text = "Удалить";
                    selectNewsButton.Visible = true;
                    break;
                default:
                    imagePath = "";
                    editButton.Text = "Добавить";
                    selectNewsButton.Visible = false;
                    break;
            }
        }

        private async void EditButtonOnClick(object sender, EventArgs e)
        {
            //string patternTitle = @"^[А-ЯЁ][а-яё]+$";
            //if (Regex.IsMatch(titleTextBox.Text, patternTitle) && (titleTextBox.TextLength < 50))
            //{
            //    MessageBox.Show("Все ОК!Title");
            //}
            //else
            //{
            //    MessageBox.Show("Бан!Title");
            //}

            //string patternDescription = @"^[А-ЯЁ][а-яё\.\-\,\!\?]+$";
            //if (Regex.IsMatch(descriptionTextBox.Text, patternDescription) && (descriptionTextBox.TextLength < 50))
            //{
            //    MessageBox.Show("Все ОК!");
            //}
            //else
            //{
            //    MessageBox.Show("Бан!");
            //}

            News news = await Core.GetNewsAsync(Database.IdNews);
            switch (actionComboBox.SelectedIndex)
            {
                case 0:
                    if (imagePath != "")
                    {
                        Core.AddNews(titleTextBox.Text, DateTime.Now, File.ReadAllBytes(imagePath), descriptionTextBox.Text);
                        code = 0;
                        titleTextBox.Text = null;
                        descriptionTextBox.Text = null;
                        imagePath = null;
                        imagePictureBox.Image = Properties.Resources.no;
                        Database.IdNews = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали картинку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                case 1:
                    if ((imagePath == "") && (code == 0) && (Database.IdNews != 0))
                    {
                        Core.UpdateNews(Database.IdNews, titleTextBox.Text, DateTime.Now, news.Photo, descriptionTextBox.Text);
                        code = 0;
                        titleTextBox.Text = null;
                        descriptionTextBox.Text = null;
                        imagePath = null;
                        imagePictureBox.Image = Properties.Resources.no;
                        Database.IdNews = 0;
                    }
                    else if ((imagePath == "") && (code == 1))
                    {
                        MessageBox.Show("Вы не выбрали картинку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Database.IdNews != 0)
                        {
                            Core.UpdateNews(Database.IdNews, titleTextBox.Text, DateTime.Now, File.ReadAllBytes(imagePath), descriptionTextBox.Text);
                            code = 0;
                            titleTextBox.Text = null;
                            descriptionTextBox.Text = null;
                            imagePath = null;
                            imagePictureBox.Image = Properties.Resources.no;
                            Database.IdNews = 0;
                        }
                        else
                        {
                            MessageBox.Show("вы ничего не выбрали");
                        }
                    }
                    break;
                case 2:
                    if (Database.IdNews != 0)
                    {
                        Core.DeleteNews(Database.IdNews);
                        code = 0;
                        titleTextBox.Text = null;
                        descriptionTextBox.Text = null;
                        imagePath = null;
                        imagePictureBox.Image = Properties.Resources.no;
                        Database.IdNews = 0;
                    }
                    else
                    {
                        MessageBox.Show("вы ничего не выбрали");
                    }
                    break;
            }
        }

        private async void SelectNewsButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdNews = 0;
                Database.Type = "News";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdNews != 0)
                {
                    News news = await Core.GetNewsAsync(Database.IdNews);
                    titleTextBox.Text = news.Title;
                    descriptionTextBox.Text = news.Description;

                    using (MemoryStream memoryStream = new MemoryStream(news.Photo))
                    {
                        imagePictureBox.Image = Bitmap.FromStream(memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

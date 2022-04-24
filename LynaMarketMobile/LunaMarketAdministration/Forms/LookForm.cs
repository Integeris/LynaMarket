using LunaMarketAdministration.Classes;
using LunaMarketEngine;
using LunaMarketEngine.Entities;
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
using Color = LunaMarketEngine.Entities.Color;

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
                    selectMaterialButton.Visible = false;
                    break;
                case 1:
                    actionMaterialButton.Text = "Изменить";
                    selectMaterialButton.Visible = true;
                    break;
                case 2:
                    actionMaterialButton.Text = "Удалить";
                    selectMaterialButton.Visible = true;
                    break;
            }
        }

        private void ActionColorComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionColorComboBox.SelectedIndex)
            {
                case 0:
                    actionColorButton.Text = "Добавить";
                    selectColorButton.Visible = false;
                    break;
                case 1:
                    actionColorButton.Text = "Изменить";
                    selectColorButton.Visible = true;
                    break;
                case 2:
                    actionColorButton.Text = "Удалить";
                    selectColorButton.Visible = true;
                    break;
            }
        }

        private void ActionMaterialButtonOnClick(object sender, EventArgs e)
        {
            //string pattern = @"^[А-ЯЁ][а-яё(?:\.| )]+[а-яё(?:\.|)]+$";

            //if (Regex.IsMatch(materialTextBox.Text, pattern) && (materialTextBox.TextLength < 50))
            //{
            //    MessageBox.Show("Все ОК!");
            //}
            //else
            //{
            //    MessageBox.Show("Бан!");
            //}

            switch (actionMaterialComboBox.SelectedIndex)
            {
                case 0:
                    Core.AddMaterial(materialTextBox.Text);
                    materialTextBox.Text = "";
                    Database.IdMaterial = 0;
                    break;
                case 1:
                    if (Database.IdMaterial != 0)
                    {
                        Core.UpdateMaterial(Database.IdMaterial, materialTextBox.Text);
                        materialTextBox.Text = "";
                        Database.IdMaterial = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы дебил!");
                    }
                    break;
                case 2:
                    if (Database.IdMaterial != 0)
                    {
                        Core.DeleteMaterial(Database.IdMaterial);
                        materialTextBox.Text = "";
                        Database.IdMaterial = 0;
                    }
                    else
                    {
                        MessageBox.Show("Вы дебил!");
                    }
                    break;
            }
        }

        private void ActionColorButtonOnClick(object sender, EventArgs e)
        {
            //string pattern = @"^[А-ЯЁ][а-яё (?:\-|)]+$";
            //if (Regex.IsMatch(colorTextBox.Text, pattern) && (colorTextBox.TextLength < 50))
            //{
            //    MessageBox.Show("Все ОК!");
            //}
            //else
            //{
            //    MessageBox.Show("Бан!");
            //}

            switch (actionColorComboBox.SelectedIndex)
            {
                case 0:
                    Core.AddColor(colorTextBox.Text);
                    colorTextBox.Text = "";
                    Database.IdMaterial = 0;
                    break;
                case 1:
                    if (Database.IdMaterial != 0)
                    {
                        Core.UpdateColor(Database.IdColor, colorTextBox.Text);
                        colorTextBox.Text = "";
                        Database.IdMaterial = 0;
                    }
                    else
                    {
                        MessageBox.Show("Капец вы дебилы! Я кнопку выбрать для кого делал?");
                    }
                    break;
                case 2:
                    if (Database.IdMaterial != 0)
                    {
                        Core.DeleteColor(Database.IdColor);
                        colorTextBox.Text = "";
                        Database.IdMaterial = 0;
                    }
                    else
                    {
                        MessageBox.Show("Капец вы дебилы! Я кнопку выбрать для кого делал?");
                    }
                    break;
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

        private async void SelectColorButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.Type = "Color";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdColor != 0)
                {
                    Color color = await Core.GetColorAsync(Database.IdColor);
                    colorTextBox.Text = color.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

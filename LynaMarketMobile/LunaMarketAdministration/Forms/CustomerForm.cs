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
                    loginTextBox.Text = null;
                    passwordTextBox.Text = null;
                    nameTextBox.Text = null;
                    surnameTextBox.Text = null;
                    emailTextBox.Text = null;
                    phoneTextBox.Text = null;
                    break;
                case 1:
                    actionCustomerButton.Text = "Изменить";
                    selectCustomerButton.Visible = true;
                    loginTextBox.Text = null;
                    passwordTextBox.Text = null;
                    nameTextBox.Text = null;
                    surnameTextBox.Text = null;
                    emailTextBox.Text = null;
                    phoneTextBox.Text = null;
                    break;
                case 2:
                    actionCustomerButton.Text = "Удалить";
                    selectCustomerButton.Visible = true;
                    loginTextBox.Text = null;
                    passwordTextBox.Text = null;
                    nameTextBox.Text = null;
                    surnameTextBox.Text = null;
                    emailTextBox.Text = null;
                    phoneTextBox.Text = null;
                    break;
            }
        }

        private void CustomerFormOnLoad(object sender, EventArgs e)
        {
            actionDeliveryComboBox.SelectedIndex = 0;
        }

        private async void SelectCustomerButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdCustomer = 0;
                Database.Type = "Customer";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdCustomer != 0)
                {
                    Customer customer = await Core.GetCustomerAsync(Database.IdCustomer);
                    loginTextBox.Text = customer.Login;
                    passwordTextBox.Text = customer.Password;
                    nameTextBox.Text = customer.FirstName;
                    surnameTextBox.Text = customer.SecondName;
                    emailTextBox.Text = customer.Email;
                    phoneTextBox.Text = customer.Phone;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActionCustomerButtonOnClick(object sender, EventArgs e)
        {
            switch (actionDeliveryComboBox.SelectedIndex)
            {
                case 0:
                    if (Database.CheckingTextBoxes(this) == 0)
                    {
                        Core.AddCustomer(loginTextBox.Text, passwordTextBox.Text, nameTextBox.Text, surnameTextBox.Text,
                                                emailTextBox.Text, passwordTextBox.Text);
                        loginTextBox.Text = null;
                        passwordTextBox.Text = null;
                        nameTextBox.Text = null;
                        surnameTextBox.Text = null;
                        emailTextBox.Text = null;
                        phoneTextBox.Text = null;
                        Database.IdCustomer = 0;
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены!");
                    }
                    break;
                case 1:
                    if (Database.IdCustomer != 0)
                    {
                        if (Database.CheckingTextBoxes(this) == 0)
                        {
                            Core.UpdateCustomer(Database.IdCustomer, loginTextBox.Text, passwordTextBox.Text,
                            nameTextBox.Text, surnameTextBox.Text, emailTextBox.Text, phoneTextBox.Text);
                            loginTextBox.Text = null;
                            passwordTextBox.Text = null;
                            nameTextBox.Text = null;
                            surnameTextBox.Text = null;
                            emailTextBox.Text = null;
                            phoneTextBox.Text = null;
                            Database.IdCustomer = 0;
                        }
                        else
                        {
                            MessageBox.Show("Не все поля заполнены!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdCustomer != 0)
                    {
                        if (Database.CheckingTextBoxes(this) == 0)
                        {
                            Core.DeleteCustomer(Database.IdCustomer);
                            loginTextBox.Text = null;
                            passwordTextBox.Text = null;
                            nameTextBox.Text = null;
                            surnameTextBox.Text = null;
                            emailTextBox.Text = null;
                            phoneTextBox.Text = null;
                            Database.IdCustomer = 0;
                        }
                        else
                        {
                            MessageBox.Show("Не все поля заполнены!");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
        }
    }
}

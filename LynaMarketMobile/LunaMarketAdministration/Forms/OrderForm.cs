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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderFormOnLoad(object sender, EventArgs e)
        {
            actionOrderComboBox.SelectedIndex = 0;
        }

        DateTime date = DateTime.Now;

        private void ActionOrderComboBoxOnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (actionOrderComboBox.SelectedIndex)
            {
                case 0:
                    actionOrderButton.Text = "Добавить";
                    selectButton.Visible = false;
                    idOrderLabel.Visible = false;
                    idOrderLabel.Text = null;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    break;
                case 1:
                    actionOrderButton.Text = "Изменить";
                    selectButton.Visible = true;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    idOrderLabel.Text = null;
                    break;
                case 2:
                    actionOrderButton.Text = "Удалить";
                    selectButton.Visible = true;
                    Database.СlearingTextBoxes(this);
                    Database.ClearFields();
                    idOrderLabel.Text = null;
                    break;
            }
        }

        private async void SelectButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.СlearingTextBoxes(this);
                Database.ClearFields();
                Database.Type = "Order";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdOrder != 0)
                {
                    Order order = await Core.GetOrderAsync(Database.IdOrder);
                    idOrderLabel.Visible = true;
                    idOrderLabel.Text = $"Заказ № {order.IdOrder}";
                    Database.IdCustomer = order.IdCustomer;
                    Database.IdOrderStatus = order.IdOrderStatus;
                    Database.IdPayMethod = order.IdPaymentMethod;
                    Database.IdPayStatus = order.IdPayStatus;
                    Database.IdDelivery = order.IdDeliveryType;

                    Customer customer = await Core.GetCustomerAsync(order.IdCustomer);
                    customerTextBox.Text = $"{customer.FirstName} {customer.SecondName}";

                    OrderStatus orderStatus = await Core.GetOrderStatusAsync(order.IdOrderStatus);
                    orderStatusTextBox.Text = orderStatus.Title;

                    PaymentMethod paymentMethod = await Core.GetPaymentMethodAsync(order.IdPaymentMethod);
                    payMethodTextBox.Text = paymentMethod.Title;

                    PayStatus payStatus = await Core.GetPayStatusAsync(order.IdPayStatus);
                    payStatusTextBox.Text = payStatus.Title;

                    DeliveryType deliveryType = await Core.GetDeliveryTypeAsync(order.IdDeliveryType);
                    deliveryTypeTextBox.Text = deliveryType.Title;

                    dateTextBox.Text = order.Date.ToString();
                    date = order.Date;
                    addressTextBox.Text = order.Address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ActionOrderButtonOnClick(object sender, EventArgs e)
        {
            switch (actionOrderComboBox.SelectedIndex)
            {
                case 0:
                    int id = await Core.AddOrder(Database.IdCustomer, Database.IdOrderStatus, Database.IdPayMethod, 
                                        Database.IdPayStatus, Database.IdDelivery, DateTime.Now, addressTextBox.Text);
                    if (id != 0)
                    {
                        Database.СlearingTextBoxes(this);
                        Database.ClearFields();
                        MessageBox.Show("Запись добавлена.");
                        idOrderLabel.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления.");
                    }
                    break;
                case 1:
                    if (Database.IdOrder != 0)
                    {
                        Core.UpdateOrder(Database.IdOrder, Database.IdCustomer, Database.IdOrderStatus, Database.IdPayMethod, 
                            Database.IdPayStatus, Database.IdDelivery, date, addressTextBox.Text);
                        Database.СlearingTextBoxes(this);
                        Database.ClearFields();
                        idOrderLabel.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
                case 2:
                    if (Database.IdOrder != 0)
                    {
                        Core.DeleteOrder(Database.IdOrder);
                        Database.СlearingTextBoxes(this);
                        Database.ClearFields();
                        idOrderLabel.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не выбрали");
                    }
                    break;
            }
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
                    customerTextBox.Text = $"{customer.FirstName} {customer.SecondName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectOrderStatusButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdOrderStatus = 0;
                Database.Type = "OrderStatus";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdOrderStatus != 0)
                {
                    OrderStatus orderStatus = await Core.GetOrderStatusAsync(Database.IdOrderStatus);
                    orderStatusTextBox.Text = orderStatus.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectPayMethodButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdPayMethod = 0;
                Database.Type = "PayMethod";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdPayMethod != 0)
                {
                    PaymentMethod paymentMethod = await Core.GetPaymentMethodAsync(Database.IdPayMethod);
                    payMethodTextBox.Text = paymentMethod.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectPayStatusButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdPayMethod = 0;
                Database.Type = "PayStatus";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdPayStatus != 0)
                {
                    PayStatus payStatus = await Core.GetPayStatusAsync(Database.IdPayStatus);
                    payStatusTextBox.Text = payStatus.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SelectDeliveryButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Database.IdDelivery = 0;
                Database.Type = "Delivery";
                SelectForm selectForm = new SelectForm();
                selectForm.ShowDialog();
                if (Database.IdDelivery != 0)
                {
                    DeliveryType delivery = await Core.GetDeliveryTypeAsync(Database.IdDelivery);
                    deliveryTypeTextBox.Text = delivery.Title;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void idOrderLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EditNewsButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                NewsForm newsForm = new NewsForm();
                newsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditLookButtonOnClick(object sender, EventArgs e)
        {
            LookForm lookForm = new LookForm();
            lookForm.ShowDialog();
        }

        private void EditManufacturerButtonOnClick(object sender, EventArgs e)
        {
            ManufacturerForm manufacturerForm = new ManufacturerForm();
            manufacturerForm.ShowDialog();
        }

        private void EditCategoriesButtonOnClick(object sender, EventArgs e)
        {
            ProductCategoryForm productCategoryForm = new ProductCategoryForm();
            productCategoryForm.ShowDialog();
        }

        private void EditDeliveryButtonOnClick(object sender, EventArgs e)
        {
            DeliveryForm deliveryForm = new DeliveryForm();
            deliveryForm.ShowDialog();
        }

        private void EditUsersButtonOnClick(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void EditProductsButtonOnClick(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
        }

        private void EditOfficeAddressButtonOnClick(object sender, EventArgs e)
        {
            OfficeAddressForm officeAddressForm = new OfficeAddressForm();
            officeAddressForm.ShowDialog();
        }

        private void EditOrderStatusButtonOnClick(object sender, EventArgs e)
        {
            OrderStatusForm orderStatusForm = new OrderStatusForm();
            orderStatusForm.ShowDialog();
        }

        private void EditPayMethodButtonOnClick(object sender, EventArgs e)
        {
            PayMethodForm payMethodForm = new PayMethodForm();
            payMethodForm.ShowDialog();
        }

        private void EditPayStatusButtonOnClick(object sender, EventArgs e)
        {
            PayStatusForm payStatusForm = new PayStatusForm();
            payStatusForm.ShowDialog();
        }

        private void EditOrderProductButtonOnClick(object sender, EventArgs e)
        {
            OrderProductForm orderProductForm = new OrderProductForm();
            orderProductForm.ShowDialog();
        }

        private void EditOrderButtonOnClick(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }
    }
}

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
    }
}

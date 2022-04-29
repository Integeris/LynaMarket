using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunaMarketAdministration.Classes
{
    internal class Database
    {
        public static string Type = "";
        public static int IdNews = 0;
        public static int IdCategory = 0;
        public static int IdDelivery = 0;
        public static int IdMaterial = 0;
        public static int IdColor = 0;
        public static int IdManufacturer = 0;
        public static int IdCustomer = 0;
        public static int Idproduct = 0;

        public static int CheckingTextBoxes(Form form)
        {
            int i = 0;
            foreach (var control in form.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    i++;
                }
            }
            return i;
        }

        public static int CheckingNumericUpDowns(Form form)
        {
            int i = 0;
            foreach (var control in form.Controls.OfType<NumericUpDown>())
            {
                if (control.Value == 0)
                {
                    i++;
                }
            }
            return i;
        }

        public static void СlearingTextBoxes(Form form)
        {
            foreach (var control in form.Controls.OfType<TextBox>())
            {
                control.Clear();
            }
        }

        public static void СlearingNumericUpDowns(Form form)
        {
            foreach (var control in form.Controls.OfType<NumericUpDown>())
            {
                control.Value = 0;
            }
        }

        public static void СlearingPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = Properties.Resources.no;
        }
    }
}

using LunaMarketAdministration.Classes;
using LunaMarketEngine;
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
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void SelectFormOnLoad(object sender, EventArgs e)
        {
            switch (Database.Type)
            {
                case "News":
                    dataGridView.DataSource = Core.GetNews().Result;
                    break;
                default:
                    break;
            }
        }
    }
}

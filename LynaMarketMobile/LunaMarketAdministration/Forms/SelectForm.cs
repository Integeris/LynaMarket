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
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private async void SelectFormOnLoad(object sender, EventArgs e)
        {
            List<News> news = await Core.GetNewsAsync();

            switch (Database.Type)
            {
                case "News":
                    dataGridView.DataSource = news;
                    break;
                default:
                    break;
            }
        }
    }
}

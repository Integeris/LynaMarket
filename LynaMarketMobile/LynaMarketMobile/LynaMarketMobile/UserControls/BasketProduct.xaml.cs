using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketProduct : ContentView
    {
        public delegate void DeleteHandle(object sender, DeleteItemArgs e);

        public event DeleteHandle Delete;

        public BasketProduct()
        {
            InitializeComponent();

            this.BindingContextChanged += BasketProductOnBindingContextChanged;
        }

        private void BasketProductOnBindingContextChanged(object sender, EventArgs e)
        {
            ((BasketProductView)this.BindingContext).PropertyChanged += BasketProductOnPropertyChanged;
        }

        private void BasketProductOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AmountEntry.Text = ((BasketProductView)sender).Amount.ToString();
        }

        private void AmountEntryOnCompleted(object sender, EventArgs e)
        {
            AmountEntry.Text = AmountEntry.Text.Replace("-", "");
            int spaceIndex = AmountEntry.Text.IndexOf(',');

            if (spaceIndex != -1)
            {
                AmountEntry.Text = AmountEntry.Text.Remove(spaceIndex);
            }

            BasketProductView context = (BasketProductView)this.BindingContext;

            try
            {
                int value = Int32.Parse(AmountEntry.Text);

                if (value > context.MaxAmount)
                {
                    value = context.MaxAmount;
                    AmountEntry.Text = value.ToString();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                AmountEntry.Text = "1";
            }
        }

        private void DeleteButtonOnClicked(object sender, EventArgs e)
        {
            Delete?.Invoke(this, new DeleteItemArgs((BasketProductView)this.BindingContext));
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            AmountChange(-1);
        }

        private void NextButtonOnClicked(object sender, EventArgs e)
        {
            AmountChange(1);
        }

        private void AmountChange(int offset)
        {
            ((BasketProductView)this.BindingContext).Amount += offset;
        }
    }
}
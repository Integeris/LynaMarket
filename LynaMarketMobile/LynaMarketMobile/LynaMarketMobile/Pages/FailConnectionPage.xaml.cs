using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FailConnectionPage : ContentPage
    {
        public FailConnectionPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
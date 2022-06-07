using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFPage : ContentPage
    {
        public PDFPage(string title, string pdfUrl)
        {
            InitializeComponent();

            MainWebView.Source = "https://www.google.com";
            this.Title = title;
            MainWebView.Source = $"https://drive.google.com/viewerng/viewer?embedded=true&url={pdfUrl}";
        }
    }
}
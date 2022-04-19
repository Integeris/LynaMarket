using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeReviewPage : ContentPage
    {
        private readonly string code;
        private bool result;

        private TimeSpan timeSpan = new TimeSpan(0, 2, 0);
        private readonly Customer customer;
        private readonly Timer timer;

        public bool Result
        {
            get => result;
        }

        public CodeReviewPage(Customer customer, string code)
        {
            this.customer = customer;
            this.code = code;

            timer = new Timer(1000);
            timer.Elapsed += TimerOnElapsed;

            InitializeComponent();

            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));
            this.Dispatcher.BeginInvokeOnMainThread(new Action(() => TimeLeftLabel.Text = $"{timeSpan.Minutes:d2}:{timeSpan.Seconds:d2}"));

            if (timeSpan == TimeSpan.Zero)
            {
                timer.Stop();
                this.Dispatcher.BeginInvokeOnMainThread(new Action(() => NavigationManager.PopPage()));
            }
        }

        private void ConfirmButtonOnClicked(object sender, EventArgs e)
        {
            timer.Stop();

            if (CodeEntry.Text != code)
            {
                InfoViewer.ShowError(this, "Код введён не верно.");
                timer.Start();

                return;
            }

            Core.AddCustomer(customer.Login, customer.Password, customer.FirstName, 
                customer.SecondName, customer.Email, customer.Phone);

            CurrentCustomer.Authorizate(customer.IdCustomer);
            result = true;
            NavigationManager.PopPage();
        }
    }
}
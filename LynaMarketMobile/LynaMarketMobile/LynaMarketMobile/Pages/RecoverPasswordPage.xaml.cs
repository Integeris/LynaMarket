using LunaMarketEngine;
using LunaMarketEngine.Entities;
using LynaMarketMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecoverPasswordPage : ContentPage
    {
        private readonly Customer customer;
        private string password;

        public RecoverPasswordPage(Customer customer)
        {
            this.customer = customer;

            InitializeComponent();
        }

        private void NextButtonOnClicked(object sender, EventArgs e)
        {
            string loginTemplte = @"^[A-Za-z][A-Za-z0-9]{7,49}$";

            try
            {
                if (!Regex.IsMatch(PasswordEntry.Text, loginTemplte))
                {
                    throw new Exception("Пароль должен состоять из букв латинского алфавита или алфавита и цифр. Длинна пароля может быть от 8 до 50 символов включительно. Первый символ должен быть латинской буквой.");
                }
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(this, ex.Message);
                return;
            }

            password = PasswordEntry.Text;
            string code = new CodeGenerator().Generate();

            MailSender mailSender = new MailSender(customer.Email)
            {
                Subject = "ОО <<Луна>>. Восстановление пароля",
                Body = $"Новый пароль: {password}\nКод для восстановления: <b>{code}</b>\nЕсли вы не восстанавливайте пароль, то просто проигнорируйте это сообщение."
            };

            mailSender.SendAsync();
            CodeReviewPage codeReviewPage = new CodeReviewPage(code);
            codeReviewPage.Disappearing += CodeReviewPageOnDisappearing;
            NavigationManager.PushPage(codeReviewPage);
        }

        private void CodeReviewPageOnDisappearing(object sender, EventArgs e)
        {
            if (((CodeReviewPage)sender).Result)
            {
                Core.UpdateCustomer(customer.IdCustomer, customer.Login, password, 
                    customer.FirstName, customer.SecondName, customer.Email, customer.Phone);

                MailSender mailSender = new MailSender(customer.Email)
                {
                    Subject = "ООО <<Луна>>. Восстановление пароля",
                    Body = $"Вы успешно восстановили пароль. Ваш новый пароль: {password}"
                };

                mailSender.SendAsync();
                InfoViewer.ShowInfo(this, "Вы успешно восстановили пароль.");
                NavigationManager.PopPage();
            }
            else
            {
                InfoViewer.ShowInfo(this, "Вы не восстановили пароль.");
            }
        }
    }
}
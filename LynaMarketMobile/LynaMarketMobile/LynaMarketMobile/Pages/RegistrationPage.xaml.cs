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
    public partial class RegistrationPage : ContentPage
    {
        Customer customer;

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegistrationButtonOnClicked(object sender, EventArgs e)
        {
            string loginTemplte = @"^[A-Za-z][A-Za-z0-9]{7,49}$";
            string namesTemplate = @"^[A-ZА-я][a-zа-я]{1,49}$";

            try
            {
                if (!Regex.IsMatch(LoginEntry.Text, loginTemplte))
                {
                    throw new Exception("Логин должен состоять из букв латинского алфавита или алфавита и цифр. Длинна логина может быть от 8 до 50 символов включительно. Первый символ должен быть латинской буквой.");
                }
                else if (await Core.GetCustomerAsync(LoginEntry.Text) != null)
                {
                    throw new Exception("Такой пользователь уже существует.");
                }
                else if (!Regex.IsMatch(PasswordEntry.Text, loginTemplte))
                {
                    throw new Exception("Пароль должен состоять из букв латинского алфавита или алфавита и цифр. Длинна пароля может быть от 8 до 50 символов включительно. Первый символ должен быть латинской буквой.");
                }
                else if (!Regex.IsMatch(EmailEntry.Text, @"^[A-Za-z][A-Za-z0-9_]*@[A-Za-z]+(.[A-Za-z]+)+$"))
                {
                    throw new Exception("Введите почту корректно.");
                }
                else if (await Core.GetCustomerAsync(EmailEntry.Text) != null)
                {
                    throw new Exception("Такой пользователь уже существует.");
                }
                else if (!(Regex.IsMatch(FirstNameEntry.Text, namesTemplate) || String.IsNullOrWhiteSpace(FirstNameEntry.Text)))
                {
                    throw new Exception("Введите своё имя корректно.");
                }
                else if (!(Regex.IsMatch(SecondNameEntry.Text, namesTemplate) || String.IsNullOrWhiteSpace(SecondNameEntry.Text)))
                {
                    throw new Exception("Введите свою фамилию корректно.");
                }
                else if (!(Regex.IsMatch(PhoneEntry.Text, @"^\+?\d{11}$") || String.IsNullOrWhiteSpace(PhoneEntry.Text)))
                {
                    throw new Exception("Введите номер телефона по шаблону: '***********' или '+***********', где * - цифра.");
                }
            }
            catch (Exception ex)
            {
                InfoViewer.ShowError(this, ex.Message);
                return;
            }

            customer = new Customer
            {
                Login = LoginEntry.Text,
                Password = PasswordEntry.Text,
                Email = EmailEntry.Text,
                FirstName = FirstNameEntry.Text,
                SecondName = SecondNameEntry.Text,
                Phone = PhoneEntry.Text
            };

            string code = new CodeGenerator().Generate();

            MailSender mailSender = new MailSender(customer.Email)
            {
                Subject = "ООО <<ЛУНА>>",
                Body = $"Код: <b>{code}</b>"
            };

            mailSender.SendAsync();

            CodeReviewPage reviewPage = new CodeReviewPage(code);
            reviewPage.Disappearing += ReviewPageOnDisappearing;
            NavigationManager.PushPage(reviewPage);
        }

        private async void ReviewPageOnDisappearing(object sender, EventArgs e)
        {
            if (((CodeReviewPage)sender).Result)
            {
                await Core.AddCustomer(customer.Login, customer.Password, customer.FirstName,
                    customer.SecondName, customer.Email, customer.Phone);

                CurrentCustomer.Authorizate(customer.IdCustomer);

                InfoViewer.ShowInfo(this, "Вы успешно зарегистрировались.");
            }
            else
            {
                InfoViewer.ShowError(this, "Вы не зарегистрировались.");
            }
        }

        private void CondidencePliticOnClicked(object sender, EventArgs e)
        {
            PDFPage confidencePage = new PDFPage("Политика конфиденциальности", "https://luna-m.ru/pdf/privacy.pdf");
            NavigationManager.PushPage(confidencePage);
        }
    }
}
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
    public partial class EditProfilePage : ContentPage
    {
        private string userLogin;

        public bool Apply { get; set; }

        public EditProfilePage()
        {
            InitializeComponent();
            LoadCustomer();
        }

        private async void LoadCustomer()
        {
            Customer customer = await Core.GetCustomerAsync(CurrentCustomer.IdCustomer);

            LoginEntry.Text = customer.Login;
            PasswordEntry.Text = customer.Password;
            EmailEntry.Text = customer.Email;
            FirstNameEntry.Text = customer.FirstName;
            SecondNameEntry.Text = customer.SecondName;
            PhoneEntry.Text = customer.Phone;

            userLogin = customer.Login;
        }

        private async void ApplyButtonOnClicked(object sender, EventArgs e)
        {
            string loginTemplte = @"^[A-Za-z][A-Za-z0-9]{7,49}$";
            string namesTemplate = @"^[A-ZА-я][a-zа-я]{1,49}$";

            try
            {
                if (!Regex.IsMatch(LoginEntry.Text, loginTemplte))
                {
                    throw new Exception("Логин должен состоять из букв латинского алфавита или алфавита и цифр. Длинна логина может быть от 8 до 50 символов включительно. Первый символ должен быть латинской буквой.");
                }
                else if (await Core.GetCustomerAsync(LoginEntry.Text) != null && LoginEntry.Text != userLogin)
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

            Core.UpdateCustomer(CurrentCustomer.IdCustomer, LoginEntry.Text,
                PasswordEntry.Text, FirstNameEntry.Text, SecondNameEntry.Text, EmailEntry.Text, PhoneEntry.Text);

            Apply = true;
            NavigationManager.PopPage();
        }
    }
}
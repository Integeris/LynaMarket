﻿using LunaMarketEngine;
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

            Customer customer = new Customer
            {
                Login = LoginEntry.Text,
                Password = PasswordEntry.Text,
                Email = EmailEntry.Text,
                FirstName = FirstNameEntry.Text,
                SecondName = SecondNameEntry.Text,
                Phone = PhoneEntry.Text
            };

            char[] chars = new char[]
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
                'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z'
            };

            char[] code = new char[5];

            {
                Random random = new Random();

                for (int i = 0; i < code.Length; i++)
                {
                    code[i] = chars[random.Next(chars.Length)];
                }
            }

            MailSender mailSender = new MailSender(customer.Email)
            {
                Subject = "ООО <<ЛУНА>>",
                Body = $"Код: <b>{new String(code)}</b>"
            };

            mailSender.SendAsync();

            CodeReviewPage reviewPage = new CodeReviewPage(customer, new String(code));
            reviewPage.Disappearing += ReviewPageOnDisappearing;
            NavigationManager.PushPage(reviewPage);
        }

        private void ReviewPageOnDisappearing(object sender, EventArgs e)
        {
            if (((CodeReviewPage)sender).Result)
            {
                InfoViewer.ShowInfo(this, "Вы успешно зарегистрировались.");
            }
            else
            {
                InfoViewer.ShowError(this, "Вы не зарегистрировались.");
            }
        }
    }
}
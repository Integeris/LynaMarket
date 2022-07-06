using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine
{
    /// <summary>
    /// Отправитель сообщений.
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        private string fromAddress = "ninellsh@gmail.com";

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        private string toAddress;

        /// <summary>
        /// Заголовок.
        /// </summary>
        private string subject;

        /// <summary>
        /// Тело.
        /// </summary>
        private string body;

        /// <summary>
        /// Сервер почты.
        /// </summary>
        private string host = "smtp.gmail.com";

        /// <summary>
        /// Пароль.
        /// </summary>
        private string password = "пароль";

        /// <summary>
        /// Порт.
        /// </summary>
        private int port = 587;

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        public string FromAddress
        {
            get => fromAddress;
            set => fromAddress = value;
        }

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        public string ToAddress
        {
            get => toAddress;
            set => toAddress = value;
        }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Subject
        {
            get => subject;
            set => subject = value;
        }

        /// <summary>
        /// Тело.
        /// </summary>
        public string Body
        {
            get => body;
            set => body = value;
        }

        /// <summary>
        /// Сервер почты.
        /// </summary>
        public string Host
        {
            get => host;
            set => host = value;
        }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }

        /// <summary>
        /// Порт.
        /// </summary>
        public int Port
        {
            get => port;
            set => port = value;
        }

        /// <summary>
        /// Конструктор без данных.
        /// </summary>
        public MailSender() { }

        /// <summary>
        /// Конструктор с отправителем.
        /// </summary>
        /// <param name="toMail"></param>
        public MailSender(string toMail)
        {
            this.toAddress = toMail;
        }

        /// <summary>
        /// Отправить.
        /// </summary>
        public async void SendAsync()
        {
            MailMessage message = new MailMessage(fromAddress, toAddress, subject, body)
            {
                IsBodyHtml = true,
                Priority = MailPriority.High
            };

            SmtpClient smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, password),
            };

            try
            {
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception) { }
        }
    }
}

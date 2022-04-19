using Microsoft.VisualStudio.TestTools.UnitTesting;
using LunaMarketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Tests
{
    [TestClass()]
    public class MailSenderTests
    {
        [TestMethod("Отпрака сообщения.")]
        public void SendTest()
        {
            MailSender sender = new MailSender("xefefal863@leafzie.com")
            {
                FromAddress = "toxaserega14@gmail.com",
                Password = "12345678+",
                Subject = "Привтет, черт.",
                Body = "Не ожидал? <b>Да?</b>"
            };

            sender.SendAsync();
        }
    }
}
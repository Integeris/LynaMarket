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
            MailSender sender = new MailSender("toxaserega14@gmail.com")
            {
                FromAddress = "ninellsh@gmail.com",
                Password = "nikt20012006",
                Subject = "Привет, черт.",
                Body = "Не ожидал? <b>Да?</b>"
            };

            sender.SendAsync();
        }
    }
}
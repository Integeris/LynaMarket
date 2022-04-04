using Microsoft.VisualStudio.TestTools.UnitTesting;
using LunaMarketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LunaMarketEngine.Entities;

namespace LunaMarketEngine.Tests
{
    [TestClass()]
    public class CoreTests
    {
        /// <summary>
        /// Проверка получения списка из базы данных.
        /// </summary>
        [TestMethod("Получение списка.")]
        public void GetDeliveryTypesTest()
        {
            try
            {
                List<DeliveryType> deliveryTypes = Core.GetDeliveryTypesAsync().Result;
                Assert.IsNotNull(deliveryTypes);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Проверка добавления объекта в базу данных.
        /// </summary>
        [TestMethod("Добавление объекта.")]
        public void AddNewsTest()
        {
            News news = new News
            {
                Title = "asdasdas",
                Description = "dasdas",
                Date = DateTime.Now,
                Photo = new byte[] { 1, 3, 5, 2 }
            };

            Core.AddNews(news.Title, news.Date, news.Photo, news.Description);
            News news2 = Core.GetNewsAsync().Result.Last();

            Assert.AreEqual(news.Date.Minute, news2.Date.Minute);
        }
    }
}
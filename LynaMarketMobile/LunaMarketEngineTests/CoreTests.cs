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
                List<DeliveryType> deliveryTypes = Core.GetDeliveryTypes().Result;
                Assert.IsNotNull(deliveryTypes);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
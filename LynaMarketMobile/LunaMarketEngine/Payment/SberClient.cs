using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace LunaMarketEngine.Payment
{
    /// <summary>
    /// Клиент по работе с API сбербанка.
    /// </summary>
    public class SberClient
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        private readonly string userName = "логин";

        /// <summary>
        /// Пароль.
        /// </summary>
        private readonly string password = "пароль";

        /// <summary>
        /// Язык.
        /// </summary>
        private readonly string language = "ru";

        /// <summary>
        /// Регистрация заказа.
        /// </summary>
        /// <param name="orderNumber">Номер заказа.</param>
        /// <param name="amount">Сумма заказа в копейках.</param>
        /// <param name="phone">Номер телефона клиента (если есть).</param>
        /// <param name="email">Почта.</param>
        /// <returns>Данные о зарегестрированном заказе.</returns>
        public RegistrationResponce RegistrationOrder(int orderNumber, int amount, string phone = null, string email = null)
        {
            UrlParametersCollection urlParametersCollection = new UrlParametersCollection()
            {
                UrlParameters =
                {
                    new UrlParameter("userName", userName),
                    new UrlParameter("password", password),
                    new UrlParameter("orderNumber", orderNumber),
                    new UrlParameter("amount", amount),
                    new UrlParameter("language", language),
                    new UrlParameter("returnUrl", "https://luna-m.ru/success.php"),
                    new UrlParameter("failUrl", "https://luna-m.ru/error.php"),
                    new UrlParameter("pageView", "MOBILE")
                }
            };

            if (phone != null)
            {
                urlParametersCollection.UrlParameters.Add(new UrlParameter("phone", phone));
            }

            if (email != null)
            {
                urlParametersCollection.UrlParameters.Add(new UrlParameter("email", email));
            }

            return GetResponce<RegistrationResponce>(urlParametersCollection, "https://3dsec.sberbank.ru/payment/rest/register.do");
        }

        ///// <summary>
        ///// Проверка оплаты.
        ///// </summary>
        ///// <param name="registrationResponce">Данные об зарегистрированном заказе.</param>
        ///// <returns>Стату проверки оплаты.</returns>
        //public StatusResponce PayStatus(RegistrationResponce registrationResponce)
        //{
        //    UrlParametersCollection urlParametersCollection = new UrlParametersCollection()
        //    {
        //        UrlParameters =
        //        {
        //            new UrlParameter("userName", userName),
        //            new UrlParameter("password", password),
        //            new UrlParameter("orderId", registrationResponce.OrderId),
        //            new UrlParameter("language", language)
        //        }
        //    };

        //    StatusResponce statusResponce;

        //    do
        //    {
        //        System.Threading.Thread.Sleep(1500);
        //        statusResponce = GetResponce<StatusResponce>(urlParametersCollection, "https://3dsec.sberbank.ru/payment/rest/getOrderStatusExtended.do");
        //    } while (statusResponce.OrderStatus != 2);

        //    return statusResponce;
        //}

        private T GetResponce<T>(UrlParametersCollection urlParametersCollection, string host)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(new Uri($"{host}?{urlParametersCollection}"));
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            HttpWebResponse httpWebResponce = (HttpWebResponse)httpWebRequest.GetResponse();
            string strJson;

            using (StreamReader stream = new StreamReader(httpWebResponce.GetResponseStream()))
            {
                strJson = stream.ReadToEnd();
            }

            return JsonSerializer.Deserialize<T>(strJson);
        }
    }
}

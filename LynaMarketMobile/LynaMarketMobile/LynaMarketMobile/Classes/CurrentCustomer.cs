using LunaMarketEngine;
using LunaMarketEngine.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    /// <summary>
    /// Текущий покупатель.
    /// </summary>
    internal static class CurrentCustomer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public static int IdCustomer { get; set; }

        /// <summary>
        /// Авторизован.
        /// </summary>
        public static bool Authorizated { get; set; }

        /// <summary>
        /// Авторизироваться.
        /// </summary>
        /// <param name="customer">Заказчик.</param>
        public static void Authorizate(int idCustomer)
        {
            IdCustomer = idCustomer;
            Authorizated = true;

            Application.Current.Properties["IdCustomer"] = IdCustomer;
            Application.Current.SavePropertiesAsync();
        }

        /// <summary>
        /// Выйти из учётной записи.
        /// </summary>
        public static void Exit()
        {
            Authorizated = false;
            Application.Current.Properties["IdCustomer"] = 0;
            Application.Current.SavePropertiesAsync();
        }
    }
}

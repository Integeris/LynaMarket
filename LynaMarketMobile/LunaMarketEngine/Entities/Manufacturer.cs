﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Производитель.
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int IdManufacturer { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Товары производителя.
        /// </summary>
        public List<Product> Products
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>()
                {
                    ["IdManufacturer"] = IdManufacturer.ToString()
                };

                return Core.GetObjectsListAsync<Product>(properties).Result;
            }
        }
    }
}

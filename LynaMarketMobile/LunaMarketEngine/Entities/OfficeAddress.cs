using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Entities
{
    /// <summary>
    /// Адрес офиса.
    /// </summary>
    public class OfficeAddress
    {
        /// <summary>
        /// Идентификатор адреса офиса.
        /// </summary>
        public int IdOfficeAddress { get; set; }

        /// <summary>
        /// Адрес офиса.
        /// </summary>
        public string Title { get; set; }
    }
}

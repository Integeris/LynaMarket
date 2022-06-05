using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine.Payment
{
    public class UrlParametersCollection
    {
        public List<UrlParameter> UrlParameters { get; private set; } = new List<UrlParameter>();

        public override string ToString()
        {
            return String.Join("&", UrlParameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LunaMarketEngine.Payment
{
    [Serializable()]
    public class StatusResponce
    {
        [JsonPropertyName("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("orderStatus")]
        public int OrderStatus { get; set; }

        [JsonPropertyName("actionCode")]
        public int ActionCode { get; set; }

        [JsonPropertyName("actionCodeDescription")]
        public string ActionCodeDescription { get; set; }

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("paymentWay")]
        public string PaymentWay { get; set; }

        [JsonPropertyName("paymentSystem")]
        public string PaymentSystem { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("productCategory")]
        public string ProductCategory { get; set; }
    }
}

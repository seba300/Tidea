using System.Collections.Generic;

namespace Tidea.Web.Models.Order
{
    public class Order
    {
        public string orderId { get; set; }
        public string extOrderId { get; set; }
        public string orderCreateDate { get; set; }
        public string notifyUrl { get; set; }
        public string customerIp { get; set; }
        public string merchantPosId { get; set; }
        public string description { get; set; }
        public string currencyCode { get; set; }
        public string totalAmount { get; set; }
        public Buyer buyer { get; set; }
        public PayMethod payMethod { get; set; }
        public List<Product> products { get; set; }
        public string status { get; set; }
    }
}
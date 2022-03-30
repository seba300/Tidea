using System.Collections.Generic;
using System.Net;
using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class CreateOrderViewModel
    {
        public string description { get; set; }
        public string totalAmount { get; set; }
        public string customerIp { get; set; }
        public Buyer buyer { get; set; } 
        public List<Product> products { get; set; }
        public string notifyUrl { get; set; }
        public string merchantPosId { get; set; }
        public string currencyCode { get; set; }
        public PayMethods payMethods { get; set; }
        public string continueUrl { get; set; }
    }
}
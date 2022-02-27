using System.Collections.Generic;
using System.Net;
using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class CreateOrderViewModel
    {
        public string description { get; set; }
        public decimal totalAmount { get; set; }
        public string customerIp { get; set; }
        public Buyer buyer { get; set; } 
        public List<Product> products { get; set; }
    }
}
using System.Collections.Generic;
using System.Net;
using Tidea.Web.Models;

namespace Tidea.Web.ViewModels
{
    public class CreateOrderViewModel
    {
        public string NotifyUrl { get; set; }
        public string IpAddress { get; set; }
        public string MerchantPosId { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal TotalAmount { get; set; }
        public Buyer Buyer { get; set; }
        public List<Product> Products { get; set; }
    }
}
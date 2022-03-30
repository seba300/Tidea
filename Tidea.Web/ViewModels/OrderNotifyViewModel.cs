using System.Collections.Generic;
using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class OrderNotifyViewModel
    {
        public Order order { get; set; }
        public string localReceiptDateTime { get; set; }
        public List<Properties> properties { get; set; }
    }
}
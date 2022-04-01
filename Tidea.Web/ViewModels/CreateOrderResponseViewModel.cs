using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class CreateOrderResponseViewModel
    {
        public Status status { get; set; }
        public string redirectUri { get; set; }
        public string orderId { get; set; }
        public string? extOrderId { get; set; }
    }
}
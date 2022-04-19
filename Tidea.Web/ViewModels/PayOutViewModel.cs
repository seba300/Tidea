using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class PayOutViewModel
    {
        public string shopId { get; set; }
        public Payout payout { get; set; }
        public Account account { get; set; }
        public CustomerAddress customerAddress { get; set; }
    }
}
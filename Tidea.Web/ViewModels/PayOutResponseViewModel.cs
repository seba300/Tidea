using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class PayOutResponseViewModel
    {
        public Payout payout { get; set; }
        public Status status { get; set; }
    }
}
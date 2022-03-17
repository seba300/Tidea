using System.Collections.Generic;
using Tidea.Web.Models.Order;

namespace Tidea.Web.ViewModels
{
    public class PayUMethodsViewModel
    {
       public List<CardToken> cardTokens { get; set; }
       public List<PexToken> pexTokens { get; set; }
       public List<PayByLink> payByLinks { get; set; }
    }
}
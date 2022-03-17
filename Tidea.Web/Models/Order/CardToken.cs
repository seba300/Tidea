namespace Tidea.Web.Models.Order
{
    public class CardToken
    {
        public string cardExpirationYear { get; set; }
        public string cardExpirationMonth { get; set; }
        public string cardNumberMasked { get; set; }
        public string cardScheme { get; set; }
        public string value { get; set; }
        public string brandImageUrl { get; set; }
        public bool preferred { get; set; }
        public string status { get; set; }
        
    }
}
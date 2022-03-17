namespace Tidea.Web.Models.Order
{
    public class PexToken
    {
        public string accountNumber { get; set; }
        public string payType { get; set; }
        public string value { get; set; }
        public string name { get; set; }
        public string brandImageUrl { get; set; }
        public bool preferred { get; set; }
        public string status { get; set; }
    }
}
namespace Tidea.Web.Models.Order
{
    //Request: GetAccessToken PayU API
    //Class which contains properties which
    //will be binded with json result from PayU API.
    public class PayUToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string grant_type { get; set; }
    }
}
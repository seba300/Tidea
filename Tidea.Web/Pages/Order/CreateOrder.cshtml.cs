using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestSharp;
using Tidea.Web.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;
using Tidea.Web.Models;
using Tidea.Web.Models.Order;

namespace Tidea.Web.Pages.Order
{
    public class CreateOrder : PageModel
    {
        private Uri baseAddress = new Uri("https://secure.snd.payu.com/");
        private const string merchantPosId = "428004";
        private const string clientId = "428004";
        private const string clientSecret = "eca193ab1e753aaa0cf8f6324561713b";
        public void OnGet()
        {
            
        }
        
        //Create Order
        public async Task<RedirectResult> OnPostAsync()
        {
            string currencyCode="PLN";
            var createOrderViewModel = new CreateOrderViewModel();
            
            string accessToken = GetAccessToken().Result.access_token;

            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer " + accessToken);
  
                using (var content = new StringContent("{\n        \"notifyUrl\": \"http://tidea.pl/notify\",\n        \"customerIp\": \"127.0.0.1\",\n        \"merchantPosId\": \"428004\",\n        \"description\": \"RTV market\",\n        \"currencyCode\": \"PLN\",\n        \"totalAmount\": \"21000\",\n        \"buyer\": {\n            \"email\": \"john.doe@example.com\",\n            \"phone\": \"654111654\",\n            \"firstName\": \"John\",\n            \"lastName\": \"Doe\",\n            \"language\": \"pl\"\n        },\n        \"products\": [\n            {\n                \"name\": \"Wireless Mouse for Laptop\",\n                \"unitPrice\": \"15000\",\n                \"quantity\": \"1\"\n            }\n        ]\n    }", System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("api/v2_1/orders/", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var redirectUri = response.RequestMessage.RequestUri.AbsoluteUri;
                        return Redirect(redirectUri);
                    }
                }
            }
        }
        
        private async Task<PayUToken> GetAccessToken()
        {
            PayUToken payUToken = null;
            
            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {
                using (var content = new StringContent("grant_type=client_credentials&client_id="+clientId+"&client_secret="+clientSecret, System.Text.Encoding.Default, "application/x-www-form-urlencoded"))
                {
                    using (var response = await httpClient.PostAsync("pl/standard/user/oauth/authorize", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        
                        //We are binding json result with prepared model class
                        payUToken = JsonConvert.DeserializeObject<PayUToken>(responseData);
                        return payUToken;
                    }
                }
            }
        }
    }
}
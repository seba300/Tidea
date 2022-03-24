using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Tidea.Web.Models.Order;

namespace Tidea.Web.Pages.Order
{

    public class TestPayUNoti : PageModel
    {
        private Uri baseAddress = new Uri("https://secure.snd.payu.com/");
        private const string clientSecret = "eca193ab1e753aaa0cf8f6324561713b";
        private const string clientId = "428004";
        
        public async Task OnGetAsync()
        {
            string accessToken = GetAccessToken().Result.access_token;
            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {
                using(var response = await httpClient.GetAsync("api/v2_1/orders"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
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
                        //Json result
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
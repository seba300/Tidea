using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestSharp;
using Tidea.Web.ViewModels;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tidea.Web.Models;
using Tidea.Web.Models.Order;

namespace Tidea.Web.Pages.Order
{
    public class CreateOrder : PageModel
    {
        private Uri baseAddress = new Uri("https://secure.snd.payu.com/");
        
        //Configuration store properties
        private const string merchantPosId = "428004";
        private const string clientId = "428004";
        private const string clientSecret = "eca193ab1e753aaa0cf8f6324561713b";
        
        
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        public Core.Entities.Campaign Campaign { get; set; }
        public PayUMethodsViewModel PayUMethods { get; set; }
        
        public CreateOrder(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //testowo na chwile, potem inicjalizacja id do usunięcia
            id = 6;
            if (id == null)
            {
                return NotFound();
            }

            Campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == id);

            if (Campaign == null)
            {
                return NotFound();
            }

            PayUMethods = GetPayMethods().Result;


            return Page();
        }
        
        [BindProperty(Name = "checkedPayUMethod")]
        public string CheckedPayUMethod { get; set; }
        
        //Create Order
        public async Task<RedirectResult> OnPostAsync()
        {
            var createOrderViewModel = new CreateOrderViewModel
            {
                merchantPosId = "428004",
                notifyUrl = "http://tidea.pl/notify",
                currencyCode = "PLN",
                description = "RTV market",
                totalAmount = "21000",
                customerIp = "127.0.0.1",
                buyer = new Buyer
                {
                    email = "john.doe@example.com",
                    phone="654111654",
                    firstName = "John",
                    lastName = "Doe",
                    language = "pl"
                },
                products = new List<Product>()
                {
                    new Product()
                    {
                        name = "Wireless Mouse for Laptop",
                        quantity = "1",
                        unitPrice = "15000"
                    }
                }
            };

            string accessToken = GetAccessToken().Result.access_token;

            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer " + accessToken);

                //JsonConvert... -> convert object to json
                using (var content = new StringContent(JsonConvert.SerializeObject(createOrderViewModel), System.Text.Encoding.Default, "application/json"))
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
                        //Json result
                        string responseData = await response.Content.ReadAsStringAsync();
                        
                        //We are binding json result with prepared model class
                        payUToken = JsonConvert.DeserializeObject<PayUToken>(responseData);
                        return payUToken;
                    }
                }
            }
        }
        
        private async Task<PayUMethodsViewModel> GetPayMethods()
        {
            PayUMethodsViewModel payUMethods = null;
            string accessToken = GetAccessToken().Result.access_token;
            
            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer" + accessToken);
  
                using(var response = await httpClient.GetAsync("api/v2_1/paymethods/"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    payUMethods = JsonConvert.DeserializeObject<PayUMethodsViewModel>(responseData);
                    return payUMethods;
                }
            }
        }
    }
}
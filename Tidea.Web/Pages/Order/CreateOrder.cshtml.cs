using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using Tidea.Core.Entities;
using Tidea.Web.Models;
using Tidea.Web.Models.Order;
using Tidea.Web.Services;

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
        public IEnumerable<PayByLink> FilteredPayUMethods { get; set; }
        public List<int> PaidInList { get; set; }
        [BindProperty(Name = "Campaign.Id")]
        public int CampaignId { get; set; }
        
        [BindProperty(Name = "remoteIpAddress")]
        public string RemoteIpAddress { get; set; }
        
        public CreateOrder(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Get user IP Address
            RemoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            
            if (id == null)
            {
                return NotFound();
            }
            
            Campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == id);

            if (Campaign == null)
            {
                return NotFound();
            }

            
            //Get PayU payment methods like blik, ipko etc.
            PayUMethods = GetPayMethods().Result;
            
            //Don't take methods PayPo, Twisto, PayU|Raty and PayU|Place pozniej
            FilteredPayUMethods = PayUMethods.payByLinks.Where(x => 
                x.value!="ai" &&
                x.value!="dpt" &&
                x.value!="dpp" &&
                x.value!="dp"
                );
            
            //Initialize paidIn buttons with values 5, 10, 20 etc.
            SetPaidInValues();

            return Page();
        }

        //Initialize PaidIn List with values
        private void SetPaidInValues()
        {
            PaidInList = new List<int>()
            {
                5, 10, 20, 50, 100, 200, 400, 500
            };
        }
        
        //Selected PayU payment method
        [BindProperty(Name = "checkedPayUMethod")]
        public string CheckedPayUMethod { get; set; }
        
        //Selected PaidIn value
        [BindProperty(Name = "checkedPaidIn")]
        public int CheckedPaidIn { get; set; }
        
        public Donation Donation { get; set; }
        
        //Create Order
        public async Task<RedirectResult> OnPostAsync()
        {
            Campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == CampaignId);
            
            string paidIn = (CheckedPaidIn * 100).ToString();

            var createOrderViewModel = new CreateOrderViewModel
            {
                merchantPosId = merchantPosId,
                notifyUrl = "https://localhost:5001/api/PayUNotify/notify",
                continueUrl = "https://localhost:5001/Order/ThanksForPayment",
                currencyCode = "PLN",
                description = Campaign.CampaignName,
                totalAmount = paidIn,
                customerIp = RemoteIpAddress,
                payMethods = new PayMethods()
                {
                   payMethod = new PayMethod()
                   {
                       type = "PBL",
                       value = CheckedPayUMethod
                   }
                },
                buyer = new Buyer
                {
                    email = "john.doe@example.com",
                    language = "pl",
                    firstName = "",
                    lastName = "",
                    phone = ""
                },
                products = new List<Product>()
                {
                    new()
                    {
                        name = "Zbiórka",
                        quantity = "1",
                        unitPrice = paidIn
                    }
                }
            };

            var createOrderResponse = CreateDonation(createOrderViewModel).Result;

            //Redirect to PayU payment page
            return Redirect(createOrderResponse.redirectUri);
        }
        
        //CreateOrder <- PayU
        private async Task<CreateOrderResponseViewModel> CreateDonation(CreateOrderViewModel createOrderViewModel)
        {
            string accessToken = GetAccessToken().Result.access_token;
            
            //Turn off auto-redirect because HttpClient doesn't show json and he is jumping 1 step further to html page
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            using (var httpClient = new HttpClient(handler){ BaseAddress = baseAddress })
            {
                CreateOrderResponseViewModel createOrderResponse = null;
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer " + accessToken);

                //JsonConvert... -> convert object to json
                using (var content = new StringContent(JsonConvert.SerializeObject(createOrderViewModel), System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("api/v2_1/orders/", content))
                    {
                        //POST response from PayU
                        string responseData = await response.Content.ReadAsStringAsync();
                        
                        //We are binding json result with prepared model class
                        createOrderResponse = JsonConvert.DeserializeObject<CreateOrderResponseViewModel>(responseData);
                
                        return createOrderResponse;
                    }
                }
            }
        }
        
        //GetAccessToken to PayU
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
        
        //Get all pay PayU methods
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
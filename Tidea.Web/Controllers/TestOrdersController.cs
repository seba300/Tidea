using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tidea.Core.Entities;
using Tidea.Web.Models.Order;
using Tidea.Web.ViewModels;

namespace Tidea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestOrdersController : Controller
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        private Donation Donation { get; set; }
        
        private Uri baseAddress = new Uri("https://secure.snd.payu.com/");
        
        //Configuration store properties
        private const string merchantPosId = "428004";
        private const string clientId = "428004";
        private const string clientSecret = "eca193ab1e753aaa0cf8f6324561713b";
        
        public TestOrdersController(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        //Pobierz listę wpłat na zbiórkę
        [HttpGet("test")]
        public async Task<IActionResult> OnGetAsync()
        {
            string accessToken = GetAccessToken().Result.access_token;
            
            List<Donation> donations = new List<Donation>();
            donations = await _context.Donations.Where(x => x.Campaign.Id == 6).ToListAsync();
            
            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer "+accessToken);

                for (int i = 0; i < donations.Count; i++)
                {
                    using(var response = await httpClient.GetAsync("api/v2_1/orders/"+donations[i].DonationId))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            
            return Ok();
        }

        // GET
        public IActionResult Index()
        {
            return View();
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
    }
}
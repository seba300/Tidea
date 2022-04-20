using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tidea;
using Tidea.Core.Entities;
using Tidea.Infrastructure.Data;
using Tidea.Web.Models.Order;
using Tidea.Web.Services;
using Tidea.Web.ViewModels;
//DO WYJAŚNIENIA Z PAYU
namespace Tidea.Web.Pages.Campaign
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TideaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public List<decimal> moneyProgress { get; set; }
        public List<string> campaignStartDate { get; set; }
        public List<string> campaignEndDate { get; set; }
        private const string ShopId = "VACUVbsW";
        private Uri baseAddress = new Uri("https://secure.snd.payu.com/");

        public IndexModel(TideaDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IList<Core.Entities.Campaign> Campaign { get;set; }
        public IActionResult OnGet()
        {
            HtmlConverter htmlConverter = new HtmlConverter();
            
            var userId = _userManager.GetUserId(_signInManager.Context.User);
            Campaign =  _context.Campaigns
                .Where(x => x.ApplicationUser.Id == userId)
                .Select(y=>new Core.Entities.Campaign
                {
                    Id=y.Id,
                    CampaignName = y.CampaignName,
                    Description = htmlConverter.ConvertHtmlToPlainText(y.Description),
                    CampaignEndDate = y.CampaignEndDate,
                    AmountNeeded = y.AmountNeeded,
                    TotalAmountCollected = y.TotalAmountCollected,
                    AvailableAmountCollected = y.AvailableAmountCollected,
                    Category = y.Category,
                    CampaignStartDate = y.CampaignStartDate,
                    Status = y.Status
                })
                .ToList();

           
            moneyProgress = new List<decimal>();
            campaignStartDate = new List<string>();
            campaignEndDate = new List<string>();

            //Money progress %
            foreach (var item in Campaign)
            {
                moneyProgress.Add((item.AvailableAmountCollected/item.AmountNeeded)*100);
            }
            
            //Start Date format
            foreach (var item in Campaign)
            {
                campaignStartDate.Add(item.CampaignStartDate.ToString("d"));
            }
                        
            //End Date format
            foreach (var item in Campaign)
            {
                campaignEndDate.Add(item.CampaignEndDate.ToString("d"));
            }

            return Page();
        }

        public IActionResult OnGetPayOut(int id)
        {
            PayOutViewModel payOutViewModel = new PayOutViewModel();
            var campaign = _context.Campaigns.Single(x => x.Id == id);
            var user =  _userManager.GetUserAsync(User);

            payOutViewModel.shopId = ShopId;
            payOutViewModel.payout = new Payout
            {
                //Provide amount in format ex. 9245 not in ex. 9245.00
                amount =  ((int)(campaign.AvailableAmountCollected*100)).ToString(),
                description = campaign.CampaignName
            };
            payOutViewModel.customerAddress = new CustomerAddress
            {
                name = user.Result.FirstName + " " + user.Result.LastName
            };
            payOutViewModel.account = new Account
            {
                accountNumber = user.Result.Iban
            };

            var result = PayOut(payOutViewModel).Result;
            
            //If everything went well and payment was send to user
            if (result.status.statusCode == "SUCCESS")
            {
                campaign.AvailableAmountCollected -= campaign.AvailableAmountCollected;
                _context.SaveChanges();
                
                TempData["PayedOutSuccess"] = "Środki ze zbiórki \""+campaign.CampaignName+"\" zostały zlecone do wypłaty na konto";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["PayedOutFailed"] = "Dostępne środki ze zbiórki \""+campaign.CampaignName+"\" nie zostały przelane na konto. Skontaktuj się z administratorem serwisu";
                return RedirectToPage("Index");
            }
        }

        //PayOut to specified account number
        private async Task<PayOutResponseViewModel> PayOut(PayOutViewModel payOutViewModel)
        {
           
            string accessToken = GetAccessToken().Result.access_token;

            using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", "Bearer "+accessToken);
  
  
                using (var content = new StringContent(JsonConvert.SerializeObject(payOutViewModel), System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("api/v2_1/payouts", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        PayOutResponseViewModel payOutResponseViewModel = new PayOutResponseViewModel();
                        
                        //We are binding json result with prepared model class
                        payOutResponseViewModel = JsonConvert.DeserializeObject<PayOutResponseViewModel>(responseData);
                
                        return payOutResponseViewModel;
                    }
                }
            }
        }
        private async Task<PayUToken> GetAccessToken()
        {
            PayUToken payUToken = null;
            
            //Configuration store properties
            const string merchantPosId = "428004";
            const string clientId = "428004";
            const string clientSecret = "eca193ab1e753aaa0cf8f6324561713b";
            
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

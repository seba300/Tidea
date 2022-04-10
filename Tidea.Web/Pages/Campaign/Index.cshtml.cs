using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tidea;
using Tidea.Core.Entities;
using Tidea.Infrastructure.Data;
using Tidea.Web.Services;

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
    }
}

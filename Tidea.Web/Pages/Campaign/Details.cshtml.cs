using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tidea;
using Tidea.Core.Entities;
using Tidea.Web.Models.Order;

namespace Tidea.Web.Pages.Campaign
{
    public class DetailsModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        public string ImagePath { get; set; }
        public int DonorsNumber { get; set; }
        public int DaysToFinish { get; set; }
        public int MoneyProgress { get; set; }
        public string FbUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }

        public DetailsModel(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        public Core.Entities.Campaign Campaign { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campaign = await _context.Campaigns
                .Where(m => m.Id == id)
                .Include(y=>y.Media)
                .SingleAsync();

            if (Campaign == null)
            {
                return NotFound();
            }

            //If campaign wasn't confirmed by admin, redirect user to main page
            if (Campaign.Status != "SUCCESSFUL" && !User.IsInRole("Administrator"))
            {
                return RedirectToPage("../Index");
            }
                
            //Path to campaign image
            ImagePath = "/CampaignsMedia/" + Campaign.Media.ImageName;

            MoneyProgress = Convert.ToInt32((Campaign.TotalAmountCollected / Campaign.AmountNeeded) * 100);

            //Number of donations
            DonorsNumber = _context.Donations
                .Count(x => x.Campaign.Id == id && x.Status=="COMPLETED");
            
            //Social media share url's
            //Error because of localhost url
            FbUrl = "https://www.facebook.com/sharer/sharer.php?u=" + Request.GetDisplayUrl();
            LinkedInUrl = "https://www.linkedin.com/sharing/share-offsite/?url="+ Request.GetDisplayUrl();
            TwitterUrl = "https://twitter.com/intent/tweet?url="+Request.GetDisplayUrl()+"&amp;text="+Campaign.CampaignName;
            
            //Days to finish the campaign
            DaysToFinish = Convert.ToInt32((Campaign.CampaignEndDate-DateTime.Now).TotalDays);
            if (DaysToFinish < 0)
            {
                DaysToFinish = 0;
            }

            return Page();
        }
        
        public void OnPostAsync()
        {
            
        }
    }
}

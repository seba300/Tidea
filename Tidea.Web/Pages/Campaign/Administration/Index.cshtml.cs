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

namespace Tidea.Web.Pages.Campaign.Administration
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly TideaDbContext _context;
        public List<string> CampaignEndDate { get; set; }

        public IndexModel(TideaDbContext context)
        {
            _context = context;
        }

        public IList<Core.Entities.Campaign> Campaign { get;set; }
        public IActionResult OnGet()
        {
            HtmlConverter htmlConverter = new HtmlConverter();
            
            Campaign =  _context.Campaigns
                .Where(x=>x.Status=="PENDING")
                .Select(x=>new Core.Entities.Campaign
                {
                    Description = htmlConverter.ConvertHtmlToPlainText(x.Description),
                    Category = x.Category,
                    AmountNeeded = x.AmountNeeded,
                    Id = x.Id,
                    CampaignName = x.CampaignName
                })
                .ToList();
            
            CampaignEndDate = new List<string>();
            
                        
            //End Date format
            foreach (var item in Campaign)
            {
                CampaignEndDate.Add(item.CampaignEndDate.ToString("d"));
            }

            return Page();
        }
    }
}

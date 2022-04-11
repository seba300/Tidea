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

namespace Tidea.Web.Pages.Campaign.Administration
{
    public class DetailsModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        public string ImagePath { get; set; }

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
    
            return Page();
        }
        
        public void OnPostAsync()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public string imagePath { get; set; }

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

            imagePath = "/CampaignsMedia/" + Campaign.Media.ImageName;

            return Page();
        }
        
        public void OnPostAsync()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tidea;
using Tidea.Core.Entities;

namespace Tidea.Web.Pages.Campaign
{
    public class DetailsModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;

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

            Campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == id);

            if (Campaign == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
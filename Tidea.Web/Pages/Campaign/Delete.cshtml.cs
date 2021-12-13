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
    public class DeleteModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;

        public DeleteModel(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campaign = await _context.Campaigns.FindAsync(id);

            if (Campaign != null)
            {
                _context.Campaigns.Remove(Campaign);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

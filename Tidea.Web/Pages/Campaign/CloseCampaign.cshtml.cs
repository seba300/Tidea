using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tidea.Core.Entities;
using Tidea.Infrastructure.Data;

namespace Tidea.Web.Pages.Campaign
{
    [Authorize]
    public class CloseCampaign : PageModel
    {
        private readonly TideaDbContext _context;
        
        private readonly UserManager<ApplicationUser> _userManager;
        public Core.Entities.Campaign Campaign { get; set; }
        

        public CloseCampaign(TideaDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet(int? id)
        {
            var user = _userManager.GetUserAsync(User);

            if (id == null)
            {
                return RedirectToPage("Index");
            }

            Campaign = _context.Campaigns.Single(x => x.Id == id);
            if (Campaign == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnGetClose(int id)
        {
            Campaign = _context.Campaigns.Single(x => x.Id == id);
            Campaign.Status = "FINISHED";
            
            _context.SaveChanges();
            
            return RedirectToPage("Index");
        }
    }
}
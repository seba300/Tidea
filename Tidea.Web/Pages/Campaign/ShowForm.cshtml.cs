using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tidea.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tidea.Web.Pages.Campaign
{
    [Authorize]
    public class ShowForm : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ShowForm(Tidea.Infrastructure.Data.TideaDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public Core.Entities.Campaign Campaign { get;set; }
        public Core.Entities.Media Media { get;set; }
        
        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(_signInManager.Context.User);
            Campaign = await _context.Campaigns
                .Where(x => x.ApplicationUser.Id == userId && x.Id==6)
                .FirstAsync();

            Media = await _context.Medias
                .Where(x => x.Id == 6)
                .FirstAsync();
        }
    }
}
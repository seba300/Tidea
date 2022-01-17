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

namespace Tidea.Web.Pages.Campaign
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(Tidea.Infrastructure.Data.TideaDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IList<Core.Entities.Campaign> Campaign { get;set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(_signInManager.Context.User);
            Campaign = await _context.Campaigns
                .Where(x => x.ApplicationUser.Id == userId)
                .ToListAsync();
        }
    }
}

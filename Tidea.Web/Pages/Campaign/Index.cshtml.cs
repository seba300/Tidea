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
    public class IndexModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;

        public IndexModel(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        public IList<Core.Entities.Campaign> Campaign { get;set; }

        public async Task OnGetAsync()
        {
            Campaign = await _context.Campaigns.ToListAsync();
        }
    }
}

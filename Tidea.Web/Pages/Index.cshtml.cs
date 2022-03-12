using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tidea.Core.Entities;
using Tidea.Infrastructure.Data;
using Tidea.Web.Services;


namespace Tidea.Web.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TideaDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, TideaDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public List<Core.Entities.Campaign> Campaigns { get; set; }
        private HtmlConverter htmlConverter { get; set; }
        public async Task OnGetAsync()
        {
            //Instance of object to provide html conversion to plain text
            htmlConverter = new HtmlConverter();
            
            Campaigns = await _context.Campaigns.OrderBy(y=>y.Id).Take(8).Select(x => new Core.Entities.Campaign
            {
                Id = x.Id,
                CampaignName = x.CampaignName,
                Description = htmlConverter.ConvertHtmlToPlainText(x.Description),
                Media = x.Media
            }).ToListAsync();

            //Specify path to the image
            foreach (var x in Campaigns)
            {
                x.Media.ImagePath = String.Concat("./CampaignsMedia/", x.Media.ImageName);
            }
        }
    }
}
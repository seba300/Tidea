using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tidea.Web.Services;

namespace Tidea.Web.Pages.Campaign
{
    public class CampaignCatalog : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Count, PageSize));
        
        private readonly Infrastructure.Data.TideaDbContext _context;
        public List<Core.Entities.Campaign> Campaigns { get; set; }
        private HtmlConverter HtmlConverter { get; set; }
        
        public CampaignCatalog(Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            //Instance of object to provide html conversion to plain text
            HtmlConverter = new HtmlConverter();
            
            var data= _context.Campaigns
                .OrderBy(y=>y.Id)
                .Where(y=>y.Status=="SUCCESSFUL")
                .Select(x => new Core.Entities.Campaign
                {
                    Id = x.Id,
                    CampaignName = x.CampaignName,
                    Description = HtmlConverter.ConvertHtmlToPlainText(x.Description),
                    Media = x.Media
                }).ToList<Core.Entities.Campaign>();

            Campaigns = GetPaginatedResult(CurrentPage, PageSize).Result;
            Count = data.Count;

            //Specify path to the image
            foreach (var x in Campaigns)
            {
                x.Media.ImagePath = String.Concat("../CampaignsMedia/", x.Media.ImageName);
            }
            
            return Page();
        }

        public async Task<List<Core.Entities.Campaign>> GetPaginatedResult(int currentPage, int pageSize = 8)
        {
            var data=await _context.Campaigns
                .OrderBy(y=>y.Id)
                .Skip((currentPage-1)*pageSize)
                .Take(pageSize)
                .Where(y=>y.Status=="SUCCESSFUL")
                .Select(x => new Core.Entities.Campaign
            {
                Id = x.Id,
                CampaignName = x.CampaignName,
                Description = HtmlConverter.ConvertHtmlToPlainText(x.Description),
                Media = x.Media
            }).ToListAsync<Core.Entities.Campaign>();
            return data;
        }
    }
}
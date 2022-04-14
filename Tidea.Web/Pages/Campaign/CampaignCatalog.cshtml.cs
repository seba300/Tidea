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
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        
        private HtmlConverter HtmlConverter { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        
        //Elements on the site
        public int PageSize { get; set; } = 8;
        
        //All pages
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<Core.Entities.Campaign> Campaigns { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public CampaignCatalog(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> OnGet(int? id)
        {
            HtmlConverter = new HtmlConverter();
            
            //If input search empty, show all campaigns
            if (String.IsNullOrEmpty(SearchString))
            {
                SearchString = "";
            }

            //All Campaigns that are accepted and filtered
            var data = _context.Campaigns
                .OrderBy(y => y.Id)
                .Where(y => y.Status == "SUCCESSFUL" && y.CampaignName.Contains(SearchString))
                .Select(x => new Core.Entities.Campaign
                {
                    Id = x.Id,
                    CampaignName = x.CampaignName,
                    Description = HtmlConverter.ConvertHtmlToPlainText(x.Description),
                    Media = x.Media
                }).ToList<Core.Entities.Campaign>();

            //Get only pagesize number of campaigns
            Campaigns = GetPaginatedResult(CurrentPage, SearchString, PageSize).Result;
            Count = data.Count;
            
            //Specify path to the image
            foreach (var x in Campaigns)
            {
                x.Media.ImagePath = String.Concat("../CampaignsMedia/", x.Media.ImageName);
            }

            return Page();
        }
        
        //Only Campaigns that will be displayed on one page
        public async Task<List<Core.Entities.Campaign>> GetPaginatedResult(int currentPage,string searchString, int pageSize = 8)
        {
            var data=await _context.Campaigns
                .OrderBy(y=>y.Id)
                .Skip((currentPage-1)*pageSize)
                .Take(pageSize)
                .Where(y=>y.Status=="SUCCESSFUL" && y.CampaignName.Contains(searchString))
                .Select(x => new Core.Entities.Campaign
                {
                    Id = x.Id,
                    CampaignName = x.CampaignName,
                    Description = HtmlConverter.ConvertHtmlToPlainText(x.Description),
                    Media = x.Media
                })
                .ToListAsync<Core.Entities.Campaign>();
            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tidea;
using Tidea.Core.Entities;
using Tidea.Web.ViewModels;
using Category = Tidea.Core.Entities.Category;

namespace Tidea.Web.Pages.Campaign
{
    public class CreateModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;

        public CreateModel(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateCampaignViewModel CreateCampaignViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Add to queue
            await _context.Campaigns.AddAsync(new Core.Entities.Campaign
            {
                CampaignName = CreateCampaignViewModel.Campaign.CampaignName,
                CampaignIntroduction = CreateCampaignViewModel.Campaign.CampaignIntroduction,
                Description = CreateCampaignViewModel.Campaign.Description,
                CampaignPurpose = CreateCampaignViewModel.Campaign.CampaignPurpose,
                AmountNeeded = CreateCampaignViewModel.Campaign.AmountNeeded,
                CampaignStartDate = CreateCampaignViewModel.Campaign.CampaignStartDate,
                CampaignEndDate = CreateCampaignViewModel.Campaign.CampaignEndDate
            });
            
            await _context.Medias.AddAsync(new Media
            {
                ImageSource = CreateCampaignViewModel.Media.ImageSource
            });

            await _context.Categories.AddAsync(new Category
            {
                CategoryName = CreateCampaignViewModel.Category.CategoryName
            });

            //Save to DB
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    
}

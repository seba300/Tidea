using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tidea.Web.Services;
using Tidea.Core.Entities;
using Tidea.Web.Models.Order;
using Tidea.Web.ViewModels;
using Category = Tidea.Core.Entities.Category;

namespace Tidea.Web.Pages.Campaign
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public CreateModel(Tidea.Infrastructure.Data.TideaDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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

            //Class which provides methods to upload files to drive
            UploadFile uploadFile = new UploadFile();
            
            //Upload image do drive and get image name with extension
            var imageName = uploadFile.UploadImage(CreateCampaignViewModel.Media.ImageFile);
            
            //Add to queue
            await _context.Campaigns.AddAsync(new Core.Entities.Campaign
            {
                CampaignName = CreateCampaignViewModel.Campaign.CampaignName,
                Description = CreateCampaignViewModel.Campaign.Description,
                AmountNeeded = CreateCampaignViewModel.Campaign.AmountNeeded,
                CampaignEndDate = CreateCampaignViewModel.Campaign.CampaignEndDate,
                Category = CreateCampaignViewModel.Category,
                CampaignStartDate = DateTime.Now,
                Media = new Media {
                    ImageName = imageName
                },
                ApplicationUser = await _userManager.GetUserAsync(User)
            });

            //Save to DB
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    
}

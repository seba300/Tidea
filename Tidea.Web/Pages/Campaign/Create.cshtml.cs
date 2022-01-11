using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tidea;
using Tidea.Core.Entities;
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
        public Core.Entities.Campaign Campaign { get; set; }
        
        [BindProperty]
        public Category Category { get; set; }
        
        [BindProperty]
        public Media Media { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("dupa");
                return Page();
            }

            _context.Campaigns.Add(Campaign);
            _context.Medias.Add(Media);
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

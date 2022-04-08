using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tidea.Core.Entities;

namespace Tidea.Web.Pages.Order
{
    [Authorize]
    public class TestAccount : PageModel
    {
        
        private readonly Infrastructure.Data.TideaDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Iban { get; set; }
        
        public TestAccount(Infrastructure.Data.TideaDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Nie znaleziono usera o ID '{_userManager.GetUserId(User)}'.");
            
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Iban = user.Iban;
            if (Iban == null)
            {
                Iban = "";
            }

            return Page();
        }
    }
}
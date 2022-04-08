using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tidea.Core.Entities;

namespace Tidea.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class Edit : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        public string Iban { get; set; }
        
        public Edit(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user.Email = Email;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Iban = Iban;
            user.UserName = Email;
            await _userManager.UpdateAsync(user);
            
            return RedirectToPage("Index");
        }
    }
}
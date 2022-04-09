using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Tidea.Core.Entities;

namespace Tidea.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ChangePasswordModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        [TempData] public string StatusMessage { get; set; }
        
        [BindProperty]
        [Required]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [BindProperty] 
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [BindProperty] 
        [StringLength(100, ErrorMessage = "Hasło musi mieć conajmniej {2} znaki i nie więcej niż {1} znaków długości",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [BindProperty] 
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Hasła muszą być takie same")]
        public string NewPasswordVerify { get; set; }
        
        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Nie znaleziono usera o ID '{_userManager.GetUserId(User)}'.");
            
            FirstName = user.FirstName;
            LastName = user.LastName;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty,errorMessage:"Hasło nie zostało pomyślnie zmienione");
                return Page();
            }
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Hasło zostało zmienione";
            TempData.Keep();
            
            return RedirectToPage("Index");
        }
    }
}
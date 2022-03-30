using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Tidea.Web.Models.Order;
using Tidea.Web.ViewModels;

namespace Tidea.Web.Pages.Order
{
   
    public class OrderNotify : PageModel
    {
        
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync([FromBody] OrderNotifyViewModel orderNotifyViewModel)
        {
            
            return Page();
        }
        
        
    }
}
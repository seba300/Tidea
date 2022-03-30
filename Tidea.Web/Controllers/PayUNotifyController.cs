using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tidea.Web.ViewModels;

namespace Tidea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayUNotifyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        //Catch PayU notify
        //https://localhost:5001/api/PayUNotify/notify
        [HttpPost("notify")]
        public async Task<IActionResult> OnPostAsync([FromBody] OrderNotifyViewModel orderNotifyViewModel)
        {
            var a = orderNotifyViewModel;
            return Ok();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tidea.Web.ViewModels;

namespace Tidea.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // GET
        [HttpGet]
        public void Get()
        {
            
        }
        
        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody] OrderNotifyViewModel orderNotifyViewModel)
        {
            var a = orderNotifyViewModel;
            return Ok();
        }
    }
}
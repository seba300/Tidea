using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tidea.Core.Entities;
using Tidea.Web.ViewModels;

namespace Tidea.Web.Controllers
{/// <summary>
 /// Add payment into DB
 /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PayUNotifyController : Controller
    {
        private readonly Tidea.Infrastructure.Data.TideaDbContext _context;
        private Donation Donation { get; set; }
        private Campaign Campaign { get; set; }
        
        public PayUNotifyController(Tidea.Infrastructure.Data.TideaDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        //Catch PayU notify
        //https://localhost:5001/api/PayUNotify/notify
        //FromHeader będzie później potrzebny do weryfikacji podpisu notyfikacji
        [HttpPost("notify")]
        public async Task<IActionResult> OnPostAsync([FromBody] OrderNotifyViewModel orderNotifyViewModel, [FromHeader(Name = "OpenPayu-Signature")] string openPayuSignature)
        {
            string paymentStatus=null;
            string paymentNotifyId = null;

            paymentNotifyId = orderNotifyViewModel.order.orderId;
            paymentStatus = orderNotifyViewModel.order.status;

            //If someone has successful donated campaign
            if (paymentStatus == "COMPLETED")
            {
                Donation = _context.Donations
                    .Where(x => x.DonationId == paymentNotifyId)
                    .Include(y=>y.Campaign)
                    .Single();
                
                if (Donation.Status == "PENDING")
                {
                    decimal payment = Convert.ToDecimal(orderNotifyViewModel.order.totalAmount) / 100;
                    
                    //Payment provision 5% for everyone donation
                    double provision = 0.95;

                    payment = payment * (decimal) provision;

                    Donation.Status = "COMPLETED";
                    Donation.DonationDate = Convert.ToDateTime(orderNotifyViewModel.order.orderCreateDate);
                    Donation.DonorEmail = orderNotifyViewModel.order.buyer.email;
                    Donation.PaidAmount = payment;

                    //Update campaign amount of money
                    Campaign = _context.Campaigns.Single(x => x.Id == Donation.Campaign.Id);
                    Campaign.TotalAmountCollected+=payment;
                    Campaign.AvailableAmountCollected+=payment;

                    await _context.SaveChangesAsync();
                }
            }
            //If someone has canceled campaign donation
            else if (paymentStatus == "CANCELED")
            {
                Donation = _context.Donations.Single(x => x.DonationId == paymentNotifyId);
                if (Donation.Status == "PENDING")
                {
                    Donation.Status = "CANCELED";
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }
    }
}
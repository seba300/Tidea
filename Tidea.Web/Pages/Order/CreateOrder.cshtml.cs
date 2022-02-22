using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestSharp;

namespace Tidea.Web.Pages.Order
{
    public class CreateOrder : PageModel
    {
        public string test { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = new RestClient("https://secure.snd.payu.com/api/v2_1/orders");
            //client.Timeout = -1;
            RestRequest request = new RestRequest("Default", Method.Post);
            request.AddHeader("Authorization", "Bearer 8818caf9-8972-4107-9745-dcf3b6285e7a");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "cookieFingerprint=7f481bc5-21c5-4360-b26d-7d1388f8fddf; payu_persistent=mobile_agent-false#");
            var body = @"{" + "\n" +
                       @"        ""notifyUrl"": ""http://tidea.pl/notify""," + "\n" +
                       @"        ""customerIp"": ""127.0.0.1""," + "\n" +
                       @"        ""merchantPosId"": ""428004""," + "\n" +
                       @"        ""description"": ""RTV market""," + "\n" +
                       @"        ""currencyCode"": ""PLN""," + "\n" +
                       @"        ""totalAmount"": ""21000""," + "\n" +
                       @"        ""buyer"": {" + "\n" +
                       @"            ""email"": ""john.doe@example.com""," + "\n" +
                       @"            ""phone"": ""654111654""," + "\n" +
                       @"            ""firstName"": ""John""," + "\n" +
                       @"            ""lastName"": ""Doe""," + "\n" +
                       @"            ""language"": ""pl""" + "\n" +
                       @"        }," + "\n" +
                       @"        ""products"": [" + "\n" +
                       @"            {" + "\n" +
                       @"                ""name"": ""Wireless Mouse for Laptop""," + "\n" +
                       @"                ""unitPrice"": ""15000""," + "\n" +
                       @"                ""quantity"": ""1""" + "\n" +
                       @"            }," + "\n" +
                       @"            {" + "\n" +
                       @"                ""name"": ""HDMI cable""," + "\n" +
                       @"                ""unitPrice"": ""6000""," + "\n" +
                       @"                ""quantity"": ""1""" + "\n" +
                       @"            }" + "\n" +
                       @"        ]" + "\n" +
                       @"    }";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            
            var response = client.ExecuteAsync(request);
            var test = response.Result.Content;
            return RedirectToPage("???");
        }
    }
}
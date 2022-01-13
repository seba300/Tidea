using Microsoft.AspNetCore.Mvc.RazorPages;
using Tidea.Core.Entities;

namespace Tidea.Web.ViewModels
{
    public class CreateCampaignViewModel
    {
        public Campaign Campaign { get; set; }
        public Media Media { get; set; }
        public Category Category { get; set; }
    }
}
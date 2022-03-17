namespace Tidea.Web.Models.Order
{
    public class Donate
    {
        public int CampaignId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public bool TenCoins { get; set; }
        public bool TwentyCoins { get; set; }
        public bool ThirtyCoins { get; set; }
    }
}
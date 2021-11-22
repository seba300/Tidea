using System;

namespace Tidea.Core.Entities
{
    public class Donations
    {
        public string Id { get; set; }
        public string CampaingId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime DonationDate { get; set; }
        public string Comment { get; set; }
        public string DonorEmail { get; set; }
    }
}
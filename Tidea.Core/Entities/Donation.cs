using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tidea.Core.Entities
{
    public class Donation
    {
        //OrderId from PayU
        [Key]
        public string DonationId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }
        
        public DateTime DonationDate { get; set; }

        public string Comment { get; set; }
        
        public string DonorEmail { get; set; }
        public string Status { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
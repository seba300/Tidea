using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tidea.Core.Entities
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] 
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [Required] 
        public DateTime DonationDate { get; set; }

        public string Comment { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Pole nie może być puste")]
        public string DonorEmail { get; set; }
        
        
        public virtual Campaign Campaign { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tidea.Core.Entities
{
    public class Campaign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł zbiórki")]
        [MaxLength(40)]
        public string CampaignName { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        
        [Display(Name = "Data rozpoczęcia kampanii")]
        public DateTime CampaignStartDate { get; set; }

        [Required]
        [Display(Name = "Data zakończenia kampanii")]
        public DateTime CampaignEndDate { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Potrzebna kwota")]
        public decimal AmountNeeded { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Zebrana kwota")]
        public decimal TotalAmountCollected { get; set; }       
        
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Dostępne pieniądze")]
        public decimal AvailableAmountCollected { get; set; }
        
        public string Status { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual Media Media { get; set; }
        public virtual Category Category { get; set; }
    }
}
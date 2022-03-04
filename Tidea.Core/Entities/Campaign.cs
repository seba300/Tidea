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
        public string CampaignName { get; set; }
        
        // [Required]
        // [Display(Name = "Wstęp zbiórki")]
        // public string CampaignIntroduction { get; set; }
        //
        // [Required]
        // [Display(Name = "Cel zbiórki")]
        // public string CampaignPurpose { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Data zakończenia kampanii")]
        public DateTime CampaignEndDate { get; set; }
        
        [Required]
        [Display(Name = "Potrzebna kwota")]
        public decimal AmountNeeded { get; set; }
        
        [Display(Name = "Zebrana kwota")]
        public decimal TotalAmountCollected { get; set; }
        
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual Media Media { get; set; }
        public virtual Category Category { get; set; }
    }
}
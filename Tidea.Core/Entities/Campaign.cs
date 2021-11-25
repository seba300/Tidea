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
        public string CampaignName { get; set; }

        [Required] 
        public string Description { get; set; }

        [Required] 
        public DateTime CampaignStartDate { get; set; }

        [Required] 
        public DateTime CampaignEndDate { get; set; }

        [Required] 
        public decimal TotalAmountCollected { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
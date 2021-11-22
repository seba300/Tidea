using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tidea.Core.Entities
{
    public class Campaing
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Nazwa kampanii")]
        public string CampaingName { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Opis kampanii")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "")]
        [Display(Name="Data rozpoczęcia kampanii")]
        public DateTime CampaingStartDate { get; set; }
                
        [Required(ErrorMessage = "")]
        [Display(Name="Data zakończenia kampanii")]
        public DateTime CampaingEndDate { get; set; }

        [Display(Name="Zebrana kwota")]
        public decimal TotalAmountCollected { get; set; }

        [Required]
        public string UserId { get; set; }
        
        
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tidea.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(11)")]
        public string Pesel { get; set; }
        
        [PersonalData]
        [Column(TypeName = "DateTime2")]
        public DateTime Birthdate { get; set; }
        
        [PersonalData]
        [Column(TypeName = "nvarchar(26)")]
        public string Iban { get; set; }
    }
}
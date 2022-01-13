using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tidea.Core.Entities
{
    public enum CategoryName
    {
        [Display(Name="Technologia")]
        Technology,
        [Display(Name="Sport")]
        Sport,
        [Display(Name="Ekologia")]
        Ecology,
        [Display(Name="Moda")]
        Fashion,
        [Display(Name="Edukacja")]
        Education,
        [Display(Name="Gry")]
        Games,
        [Display(Name="Książki")]
        Books
    }
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] 
        public CategoryName CategoryName { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
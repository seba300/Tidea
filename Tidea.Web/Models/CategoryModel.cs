using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tidea.Web.Models
{
    public enum Category
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
    public class CategoryModel
    {
        public Category Category { get; set; }
    }
}
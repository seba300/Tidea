using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tidea.Core.Entities
{
    public class Media
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string VideoUrl { get; set; }
        [Required]
        public virtual Campaign Campaign { get; set; }
    }
}
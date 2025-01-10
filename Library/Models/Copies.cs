using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Copies
    {
        [Key] public int CopyId { get; set; }
        [ForeignKey("Books")] [Required] public int BookId { get; set; }
        public Books Book { get; set; }
        [Column(TypeName = "BIT")]
        public bool IsAvailable { get; set; } = true;
    }
}

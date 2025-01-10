using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Name { get; set; }

    }
}

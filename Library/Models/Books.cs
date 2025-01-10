using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Books
    {
        [Key]
        public int Id {get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set;}
        [Column(TypeName = "char(4)")]
        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Incorrect year")]
        public string EditionYear { get; set;}
        [Column(TypeName = "varchar(200)")]
        [Required]
        [MaxLength(200)]
        public string Description { get; set;}
        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set;}
        public Category Category { get; set;}
    }
}

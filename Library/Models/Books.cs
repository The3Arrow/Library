using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Books
    {
        [Key]
        public int Id {get; set; }
        [Column(TypeName = "varchar(50)")] 
        public string Title { get; set;}
        [Column(TypeName = "char(4)")]
        public string EditionYear { get; set;}
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set;}
        [ForeignKey("Category")]
        public int CategoryId { get; set;}
        public Category Category { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Clients
    {
        [Key] public int ClientId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[A-Z][a-z]{1,49}$", ErrorMessage = "Wrong name")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[A-Z][a-z]{1,49}$", ErrorMessage = "Wrong surname")]
        public string Surname { get; set; }

    }
}

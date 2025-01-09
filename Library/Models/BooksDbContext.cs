using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
    }
}

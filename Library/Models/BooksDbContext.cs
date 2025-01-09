using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Copies> Copies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed dla kategorii
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Komedia" },
            new Category { Id = 2, Name = "Akcja" },
            new Category { Id = 3, Name = "Dramat" }
            );
            // Seed dla filmów
            modelBuilder.Entity<Books>().HasData(
            new Books
            {
                Id = 1,
                Title = "Book 1",
                EditionYear = "2024",
                Description = "Opis 1",
                CategoryId = 1
            },
            new Books
            {
                Id = 2,
                Title = "Film 2",
                EditionYear = "2023",
                Description = "Opis 2",
                CategoryId = 2
            }
            );
        }
    }
}

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
            new Category { Id = 1, Name = "Novel" },
            new Category { Id = 2, Name = "Fairy tale" },
            new Category { Id = 3, Name = "Ballad" }
            );
            modelBuilder.Entity<Copies>().HasData(
            new Copies { CopyId = 1, BookId = 1, IsAvailable = true },
            new Copies { CopyId = 2, BookId = 1, IsAvailable = true },
            new Copies { CopyId = 3, BookId = 2, IsAvailable = true },
            new Copies { CopyId = 4, BookId = 3, IsAvailable = true },
            new Copies { CopyId = 5, BookId = 4, IsAvailable = true },
            new Copies { CopyId = 6, BookId = 5, IsAvailable = true }
            );
            // Seed dla filmów
            modelBuilder.Entity<Books>().HasData(
            new Books
            {
                Id = 1,
                Title = "Pride and Prejudice",
                EditionYear = "1813",
                Description = "A witty romantic drama by Jane Austen exploring love, social class, and misunderstandings in 19th-century England.",
                CategoryId = 1
            },
            new Books
            {
                Id = 2,
                Title = "Moby-Dick",
                EditionYear = "1851",
                Description = "Herman Melville's epic tale of Captain Ahab's obsessive quest to hunt the elusive white whale, Moby Dick.",
                CategoryId = 1
            },
            new Books
            {
                Id = 3,
                Title = "The Little Mermaid",
                EditionYear = "1837",
                Description = "Hans Christian Andersen's poignant fairy tale about a mermaid who dreams of life on land and sacrifices everything for love.",
                CategoryId = 2
            },
            new Books
            {
                Id = 4,
                Title = "Snow White",
                EditionYear = "1812",
                Description = "From the Brothers Grimm, this classic tale tells the story of a princess, her wicked stepmother, and seven helpful dwarfs.",
                CategoryId = 2
            },
            new Books
            {
                Id = 5,
                Title = "The Rime of the Ancient Mariner",
                EditionYear = "1798",
                Description = "Samuel Taylor Coleridge's haunting lyrical ballad about a mariner cursed after killing an albatross at sea.",
                CategoryId = 3
            }

            );
        }
    }
}

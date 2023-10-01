using Microsoft.EntityFrameworkCore;
using NewLab1_MinimalAPI.Models;

namespace NewLab1_MinimalAPI.Data
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options) : base(options) 
        {
                
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Around the World in Eighty Days",
                    Author = "Jules Verne",
                    IsAvaliabel = true,
                    ReleaseYear = 1873,
                    Genre = "Äventyrsroman"

                },
                new Book()
                {
                    Id = 2,
                    Title = "Twenty Thousand Leagues Under the Seas",
                    Author = "Jules Verne",
                    IsAvaliabel = true,
                    ReleaseYear = 1870,
                    Genre = "Science fiction"

                },
                 new Book()
                 {
                     Id = 3,
                     Title = "The Count of Monte Cristo",
                     Author = "Alexandre Dumas",
                     IsAvaliabel = false,
                     ReleaseYear = 1995,
                     Genre = "Historical novel"
                 },
                 new Book()
                 {
                     Id = 4,
                     Title = "The God Delusion",
                     Author = "Richard Dawkins",
                     IsAvaliabel = true,
                     ReleaseYear = 1995,
                     Genre = "Fact"
                 },
                 new Book()
                 {
                     Id = 5,
                     Title = "The Holy Bible",
                     Author = "Unknown / King James Bible",
                     IsAvaliabel = true,
                     ReleaseYear = 0000,
                     Genre = "Religious Text"
                 }

            );
        }

    }
}

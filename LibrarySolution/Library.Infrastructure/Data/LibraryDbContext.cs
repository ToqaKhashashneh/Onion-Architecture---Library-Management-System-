using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class LibraryDbContext: DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<BookCategory> BookCategories => Set<BookCategory>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BookCategory>().HasKey(x => new { x.BookId, x.CategoryId });

            mb.Entity<BookCategory>()
              .HasOne(bc => bc.Book).WithMany(b => b.BookCategories)
              .HasForeignKey(bc => bc.BookId);

            mb.Entity<BookCategory>()
              .HasOne(bc => bc.Category).WithMany(c => c.BookCategories)
              .HasForeignKey(bc => bc.CategoryId);
        }

    }
}

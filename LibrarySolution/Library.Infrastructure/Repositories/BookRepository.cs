using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        public BookRepository(LibraryDbContext db)
        {
            _db = db;
        }

        public Task<Book?> GetBookById(int id) 
        {
          return  _db.Books.Include(b => b.BookCategories)
                     .ThenInclude(x => x.Category)
                     .FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task<IList<Book>> GetAllBooks()
        {
            return await _db.Books.Include(b => b.BookCategories)
                                  .ThenInclude(x => x.Category)
                                  .ToListAsync();
        }

        public async Task AddBook(Book book) 
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();


        }

        public async Task UpdateBook(Book book)
        { 
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        { 
            var b = _db.Books.Find(id);
            if (b != null)
            {
                _db.Books.Remove(b);
                await _db.SaveChangesAsync();
            }

        }



    }
}

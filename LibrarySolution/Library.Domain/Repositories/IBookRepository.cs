using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Domain.Repositories
{
    public interface IBookRepository
    {

        Task<Book?> GetBookById(int id);

        Task<IList<Book>> GetAllBooks();

        Task AddBook (Book book);

        Task UpdateBook (Book book);

        Task DeleteBook(int id);

    }
}

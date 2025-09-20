using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;

namespace Library.Application.Abstractions
{
    public interface IBookService
    {
        Task<BookDto?> GetBookById(int id);

        Task<List<BookDto>> GetAllBooks();

        Task <int> CreateBook(CreatedBookDto book);

        Task UpdateBook(UpdatedBookDto book);

        Task DeleteBook(int id);

        // Special method with ADO.NET stored procedure
        Task<List<(int BookId, string Title, string? Author, DateTime? PublishedOn, List<string> Categories)>>
            GetAllWithCategoriesSPAsync();


    }
}

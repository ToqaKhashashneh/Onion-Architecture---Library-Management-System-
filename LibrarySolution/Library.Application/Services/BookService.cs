using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Abstractions;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Repositories;

namespace Library.Application.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _books;
        private readonly ICategoryRepository _cats;
        private readonly IBooksSpReader _booksSpReader;

        public BookService(IBookRepository books, ICategoryRepository cats, IBooksSpReader booksSpReader )
        {
            _books = books;
            _cats = cats;
            _booksSpReader = booksSpReader;
        }

        public async Task<BookDto?> GetBookById(int id)
        { 
            var b = await _books.GetBookById(id);
            return b is null ? null : new BookDto(
             b.Id,
             b.Title,
             b.Author,
             b.PublishedOn,
             b.BookCategories.Select(bc => bc.CategoryId).ToList());
        }


        public async Task<List<BookDto>> GetAllBooks()
        {
            var list = await _books.GetAllBooks();
            return list.Select(b => new BookDto(
                b.Id, 
                b.Title, 
                b.Author, 
                b.PublishedOn, 
                b.BookCategories.Select(c => c.CategoryId).ToList())
            ).ToList();
        }

        public async Task<int> CreateBook(CreatedBookDto dto)
        {
            var book = new Book 
            { Title = dto.Title,
              Author = dto.Author,
              PublishedOn = dto.PublishedOn };
            book.BookCategories = dto.CategoryIds.Select(id => 
            new BookCategory { CategoryId = id, Book = book }).ToList();
            await _books.AddBook(book);
            return book.Id;
        }


        public async Task UpdateBook(UpdatedBookDto dto)
        {
            var b = await _books.GetBookById(dto.Id) ?? throw new KeyNotFoundException();
            b.Title = dto.Title;
            b.Author = dto.Author;
            b.PublishedOn = dto.PublishedOn;

            // replace categories
            b.BookCategories.Clear();
            foreach (var cid in dto.CategoryIds)
                b.BookCategories.Add(new BookCategory { BookId = b.Id, CategoryId = cid });
            await _books.UpdateBook(b);
        }
        public async Task DeleteBook(int id)
        {
            await _books.DeleteBook(id);
        }

        public Task<List<(int, string, string?, DateTime?, List<string>)>> GetAllWithCategoriesSPAsync()
    => _booksSpReader.ReadAllWithCategoriesAsync();
    }


}

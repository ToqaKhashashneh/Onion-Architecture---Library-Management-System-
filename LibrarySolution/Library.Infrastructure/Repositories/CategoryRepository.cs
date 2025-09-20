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
    public class CategoryRepository: ICategoryRepository
    {
        private readonly LibraryDbContext _db;

        public CategoryRepository (LibraryDbContext db)
        {
            _db = db;
        }


        public Task<Category?> GetCategoryById(int id)
        {
            return _db.Categories.Include(x=>x.BookCategories)
                                    .ThenInclude(bc => bc.Book)
                                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Category>> GetAllCategories()
        { 
            return await _db.Categories.Include(x=>x.BookCategories)
                                    .ThenInclude(bc => bc.Book)
                                    .ToListAsync();
        }

        public async Task AddCategory(Category category) 
        {
            _db.Categories.Add(category);
           await _db.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
             _db.Categories.Update(category);
           await  _db.SaveChangesAsync();

        }

        public async Task DeleteCategory(int id)
        {
            var c = _db.Categories.Find(id);
            if (c != null)
            {
                _db.Categories.Remove(c);
                await _db.SaveChangesAsync();
            }

        }


    }
}

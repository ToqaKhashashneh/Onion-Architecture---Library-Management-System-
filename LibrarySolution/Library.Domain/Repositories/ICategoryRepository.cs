using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Domain.Repositories
{
   public  interface ICategoryRepository
    {
        Task<Category?> GetCategoryById(int id);

        Task<IList<Category>> GetAllCategories();

        Task AddCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int id);

    }
}

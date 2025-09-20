using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs;

namespace Library.Application.Abstractions
{
    public interface ICategoryService
    {

        Task<CategoryDto?> GetCategoryById(int id);

        Task<List<CategoryDto>> GetAllCategories();

        Task<int> CreateCategory(CreatedCategoryDto category);

        Task UpdateCategory(UpdatedCategoryDto category);
        Task DeleteCategory(int id);



    }
}

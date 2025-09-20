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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categories;

        public CategoryService(ICategoryRepository categories)
        {
            _categories = categories;
        }


        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            var c = await _categories.GetCategoryById(id);
            return c is null ? null : new CategoryDto(c.Id, c.Name);
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var list = await _categories.GetAllCategories();
            return list.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
        }


        public async Task<int> CreateCategory(CreatedCategoryDto dto)
        {
            var category = new Category { Name = dto.Name };
            await _categories.AddCategory(category);
            return category.Id;
        }

        public async Task UpdateCategory(UpdatedCategoryDto dto)
        {
            var c = await _categories.GetCategoryById(dto.Id) ?? throw new KeyNotFoundException();
            c.Name = dto.Name;
            await _categories.UpdateCategory(c);
        }

        public async Task DeleteCategory(int id)
        {
            await _categories.DeleteCategory(id);
        }

    }
}

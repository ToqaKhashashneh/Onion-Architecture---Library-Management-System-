using Library.Application.Abstractions;
using Library.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _svc;

        public CategoryController(ICategoryService svc) 
        {
            _svc = svc;
        }

        // GET: api/category/GetAllCategories

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _svc.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/category/GetCategoryById/5

        [HttpGet("GetCategoryById/{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _svc.GetCategoryById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // POST: api/category/AddCategory
        [HttpPost("AddCategory")]
        public async Task<ActionResult<int>> CreateCategory(CreatedCategoryDto dto)
        {
            var id = await _svc.CreateCategory(dto);
            return CreatedAtAction(nameof(GetCategoryById), new { id }, id);
        }


        // PUT: api/category/UpdateCategory/5
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdatedCategoryDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch");

            await _svc.UpdateCategory(dto);
            return NoContent();
        }

        // DELETE: api/category/DeleteCategory/5
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _svc.DeleteCategory(id);
            return NoContent();
        }


    }
}

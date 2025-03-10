using Microsoft.AspNetCore.Mvc;
using sportify.Datalayer.Interfaces;
using sportify.Datalayer.DTOs;
using sportify.core.cs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sportify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _categoryRepo;

        // Inject the Category repository through constructor
        public CategoryController(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // Create a new category
        [HttpPost]
        public async Task<ActionResult<int>> CreateCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Category data is required.");
            }

            try
            {
                var categoryId = await _categoryRepo.CreateCategoryAsync(categoryDto);
                return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = categoryId }, categoryId);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Get a category by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return Ok(category);
        }

        // Get all categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();

            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }

            return Ok(categories);
        }

        // Update an existing category
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Category data is required.");
            }

            if (id != categoryDto.id)
            {
                return BadRequest("Category ID in the URL does not match the category ID in the body.");
            }

            try
            {
                var updated = await _categoryRepo.UpdateCategoryAsync(categoryDto);
                if (!updated)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                return NoContent(); // No content to return, but indicates successful update
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Delete a category by its ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                var deleted = await _categoryRepo.DeleteCategoryAsync(id);
                if (!deleted)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                return NoContent(); // Successful deletion (no content to return)
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

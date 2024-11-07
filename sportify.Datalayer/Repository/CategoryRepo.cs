using sportify.core.cs; // Assuming Category is in this namespace
using sportify.Datalayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sportify.Datalayer.DTOs;

namespace sportify.Datalayer.Repository
{
    public class CategoryRepo : ICategory
    {
        private readonly SportifyContext _context;

        public CategoryRepo(SportifyContext context)
        {
            _context = context;
        }

        // Create a new category
        public async Task<int> CreateCategoryAsync(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var newcategory = new Category
            {
                Name = category.Name,
            };

            _context.category.Add(newcategory);
            await _context.SaveChangesAsync();

            return category.id;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.category
                                 .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.category.ToListAsync();
        }

        // Update an existing category
        public async Task<bool> UpdateCategoryAsync(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            // Check if the category exists in the database
            var existingCategory = await _context.category
                                                 .FirstOrDefaultAsync(c => c.id == category.id);
            if (existingCategory == null)
                return false;

            // Update the existing category
            existingCategory.Name = category.Name;
            existingCategory.Name = category.Name;

            _context.category.Update(existingCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        // Delete a category by its ID
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            // Find the category by ID
            var category = await _context.category
                                         .FirstOrDefaultAsync(c => c.id == id);
            if (category == null)
                return false;

            // Remove the category from the database
            _context.category.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

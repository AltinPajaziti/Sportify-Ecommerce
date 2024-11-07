using sportify.core.cs;
using sportify.Datalayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportify.Datalayer.Interfaces
{
    public interface ICategory
    {

        Task<int> CreateCategoryAsync(CategoryDto category);

        Task<Category> GetCategoryByIdAsync(int id);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<bool> UpdateCategoryAsync(CategoryDto category);

        Task<bool> DeleteCategoryAsync(int id);
    }
}

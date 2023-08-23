using MVCProject.Models;

namespace MVCProjectWeb.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<bool> UpdateCategoryAsync(int id, Category category);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id);
    }
}

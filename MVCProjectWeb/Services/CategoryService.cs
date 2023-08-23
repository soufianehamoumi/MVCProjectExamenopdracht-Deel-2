using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProjectWeb.Data;
using System.Net;

namespace MVCProjectWeb.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5000/api/CategoryAPI"; // Update with your API URL
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("GetCategory");
            response.EnsureSuccessStatusCode();

            var categories = await response.Content.ReadFromJsonAsync<List<Category>>();
            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            var response = await _httpClient.GetAsync($"GetCategory/{id}");
            response.EnsureSuccessStatusCode();

            var category = await response.Content.ReadFromJsonAsync<Category>();
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            var response = await _httpClient.PutAsJsonAsync($"PutCategory/{id}", category);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            return false;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("PostCategory", category);
            response.EnsureSuccessStatusCode();

            var createdCategory = await response.Content.ReadFromJsonAsync<Category>();
            return createdCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteCategory/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            return false;
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"CategoryExists/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();
            return false;
        }

      
    }

}

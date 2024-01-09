

using BookStore.Domain.Entities;

namespace BookStore.Business.Services.CategoryService;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryAsync(int id);

    Task<string> DeleteCategoryAsync(int id);

    Task<string> AddCategoryAsync(Category category);

    Task<string> UpdateCategoryAsync(int id, Category category);
}

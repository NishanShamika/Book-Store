using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetCategoryAsync(int id);

        Task DeleteCategoryAsync(int id);

        Task AddCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);
    }
}

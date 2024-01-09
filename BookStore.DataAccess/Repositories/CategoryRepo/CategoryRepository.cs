using BookStore.Application.Interfaces.Repositories;
using BookStore.DataAccess.Data;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.DataAccess.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public CategoryRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCategoryAsync(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred while adding a category", e);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(id);
                _dbContext.Categories.Remove(category!);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred", e);
            }
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return (await _dbContext.Categories.FindAsync(id))!;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            try
            {
                _dbContext.Entry(category).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred", e);
            }
        }
    }
}

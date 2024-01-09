using BookStore.Application.Interfaces.Repositories;
using BookStore.Domain.Entities;

namespace BookStore.Business.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        if (categories is null || !categories.Any())
        {
            //return NotFound();
        }
        return categories;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryAsync(id);

        if (category is null)
        {
            //return NotFound();
        }
        return category;
    }

    public async Task<string> AddCategoryAsync(Category category)
    {
        try
        {
            await _categoryRepository.AddCategoryAsync(category);
        }
        catch (Exception)
        {

            throw;
        }
        return "Category Added Successfully";
    }

    public async Task<string> UpdateCategoryAsync(int id, Category category)
    {
        try
        {
            if (id != category.Id)
            {
                //return BadRequest();
            }
            await _categoryRepository.UpdateCategoryAsync(category);
        }
        catch (Exception)
        {

            throw;
        }
        return "Category Updated Successfully";
    }

    public async Task<string> DeleteCategoryAsync(int id)
    {
        try
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }
        catch (Exception)
        {

            throw;
        }
        return "Category Successssfully Deleted";
    }
}

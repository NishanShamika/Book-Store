using BookStore.Business.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Domain.Entities;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var response = await _categoryService.GetCategoriesAsync();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var response = await _categoryService.GetCategoryAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var response = await _categoryService.AddCategoryAsync(category);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var response = await _categoryService.UpdateCategoryAsync(id, category);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);
            return Ok(response);
        }
    }
}

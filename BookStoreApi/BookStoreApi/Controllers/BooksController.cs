using BookStore.Application.ViewModels.BookViewModels;
using BookStore.Business.Services.BookService;
using BookStore.Business.ViewModels.BookViewModels;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookVM>>> Get()
        {
            var response = await _bookService.GetBooksAsync();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookVM>> GetById(int id)
        {
            var response = await _bookService.GetBookAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookAddVM bookVM)
        {
            var response = await _bookService.AddBookAsync(bookVM);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookVM book)
        {
            var response = await _bookService.UpdateBookAsync(id, book);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookService.DeleteBookAsync(id);
            return Ok(response);
        }

        [HttpGet("category/{categoryid:int}")]
        public async Task<ActionResult<IEnumerable<BookVM>>> GetByCategory(int categoryid)
        {
            var response = await _bookService.GetBooksByCategoryAsync(categoryid);
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookVM>>> SearchBook(string? keyword)
        {
            var response = await _bookService.SearchBooksAsync(keyword);
            return Ok(response);
        }

        [HttpGet("error")]
        public async Task<ActionResult<IEnumerable<BookVM>>> ErrTest(string? keyword)
        {
            throw new NotImplementedException();
        }
    }
}

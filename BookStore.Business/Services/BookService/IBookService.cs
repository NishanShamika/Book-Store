using BookStore.Application.ViewModels.BookViewModels;
using BookStore.Business.ViewModels.BookViewModels;
using BookStore.Domain.Entities;

namespace BookStore.Business.Services.BookService;

public interface IBookService
{
    Task<IEnumerable<BookVM>> GetBooksAsync();

    Task<BookVM> GetBookAsync(int id);

    Task<string> DeleteBookAsync(int id);

    Task<string> AddBookAsync(BookAddVM bookVM);

    Task<string> UpdateBookAsync(int id, BookVM book);

    Task<IEnumerable<BookVM>> GetBooksByCategoryAsync(int categoryid);

    Task<IEnumerable<BookVM>> SearchBooksAsync(string? keyword);
}

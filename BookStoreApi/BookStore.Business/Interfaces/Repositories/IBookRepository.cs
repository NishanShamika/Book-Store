

using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(int id);

        Task DeleteBookAsync(int id);

        Task AddBookAsync(Book book);

        Task UpdateBookAsync(Book book);
    }
}

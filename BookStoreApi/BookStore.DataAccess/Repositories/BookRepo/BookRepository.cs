using BookStore.Application.Interfaces.Repositories;
using BookStore.DataAccess.Data;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.DataAccess.Repositories.BookRepo
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookAsync(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred", e);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                var book = await _dbContext.Books.FindAsync(id);
                _dbContext.Books.Remove(book!);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred", e);
            }
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return (await _dbContext.Books.FindAsync(id))!;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                _dbContext.Entry(book).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred", e);
            }
        }
    }
}

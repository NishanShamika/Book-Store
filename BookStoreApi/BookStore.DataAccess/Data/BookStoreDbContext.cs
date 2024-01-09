using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Data;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
}

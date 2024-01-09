using BookStore.Application.Helpers;
using BookStore.Application.Helpers.Exceptions;
using BookStore.Application.Interfaces.Repositories;
using BookStore.Application.ViewModels.BookViewModels;
using BookStore.Business.ViewModels.BookViewModels;
using BookStore.Domain.Entities;
using System.Net;

namespace BookStore.Business.Services.BookService;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookVM>> GetBooksAsync()
    {
        var books = await _bookRepository.GetBooksAsync();
        if (books is null || !books.Any())
        {
            throw new CustomeException
            {
                CustomMessage = $"Books Not Found",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        //var bookVmList = new List<BookVM>();

        //foreach (var book in books)
        //{
        //    var mappedToBookVM = new BookVM
        //    {
        //        Title = book.Title,
        //        PublicationYear = book.PublicationYear,
        //        CategoryId = book.CategoryId,
        //        Id = book.Id,
        //        Author = book.Author,
        //    };

        //    bookVmList.Add(mappedToBookVM);
        //}

        //return bookVmList;

        return books.Select(b => new BookVM
        {
            Author = b.Author,
            Id = b.Id,
            CategoryId = b.CategoryId,
            PublicationYear = b.PublicationYear,
            Title = b.Title
        });
    }

    public async Task<BookVM> GetBookAsync(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);

        if (book is null)
        {
            throw new CustomeException
            {
                CustomMessage = $"Book for {id} Not Found",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }
        var mappedToBookVM = new BookVM
        {
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            CategoryId = book.CategoryId,
            Id = book.Id,
            Author = book.Author,
        };
        return mappedToBookVM;
    }

    public async Task<string> AddBookAsync(BookAddVM bookVM)
    {
        try
        {
            //validate book vm
            //map bookvm to book model

            var book = new Book
            {
                Title = bookVM.Title,
                Author = bookVM.Author,
                PublicationYear = bookVM.PublicationYear,
                CategoryId = bookVM.CategoryId,
            };

            await _bookRepository.AddBookAsync(book);
        }
        catch (Exception)
        {

            throw;
        }
        return "Book Added Successfully";
    }

    public async Task<string> UpdateBookAsync(int id, BookVM bookVM)
    {
        try
        {
            if (id != bookVM.Id)
            {
                throw new CustomeException
                {
                    CustomMessage = "Invalid ID",
                    HttpStatusCode = HttpStatusCode.BadRequest
                };
            }

            var book = new Book
            {
                Id = id,
                Title = bookVM.Title,
                Author = bookVM.Author,
                PublicationYear = bookVM.PublicationYear,
                CategoryId = bookVM.CategoryId,
            };
            await _bookRepository.UpdateBookAsync(book);
        }
        catch (Exception)
        {

            throw;
        }
        return "Book Updated Successfully";
    }

    public async Task<string> DeleteBookAsync(int id)
    {
        try
        {
            await _bookRepository.DeleteBookAsync(id);
        }
        catch (Exception)
        {

            throw;
        }
        return "Book Successssfully Deleted";
    }

    public async Task<IEnumerable<BookVM>> GetBooksByCategoryAsync(int categoryid)
    {
        var books = (await _bookRepository.GetBooksAsync()).Where(b => b.CategoryId == categoryid);
        if (books is null || !books.Any())
        {
            throw new CustomeException
            {
                CustomMessage = $"Books Not Found",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        return books.Select(b => new BookVM
        {
            Author = b.Author,
            Id = b.Id,
            CategoryId = b.CategoryId,
            PublicationYear = b.PublicationYear,
            Title = b.Title
        });
    }

    public async Task<IEnumerable<BookVM>> SearchBooksAsync(string? keyword)
    {
        var books = await _bookRepository.GetBooksAsync();
            
        if (keyword is not null)
        {
            books = books.Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword));
        }

        if (books is null || !books.Any())
        {
            throw new CustomeException
            {
                CustomMessage = $"Books Not Found",
                HttpStatusCode = HttpStatusCode.NotFound
            };
        }

        return books.Select(b => new BookVM
        {
            Author = b.Author,
            Id = b.Id,
            CategoryId = b.CategoryId,
            PublicationYear = b.PublicationYear,
            Title = b.Title
        });
    }
}

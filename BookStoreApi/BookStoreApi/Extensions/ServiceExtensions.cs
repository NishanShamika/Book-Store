using BookStore.Application.Interfaces.Repositories;
using BookStore.Business.Services.BookService;
using BookStore.Business.Services.CategoryService;
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repositories.BookRepo;
using BookStore.DataAccess.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookStore.Api.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookRepository, BookRepository>();


        //Singleton - start to end of the application
        //Scoped - 
        //Transient -

        services.AddDbContext<BookStoreDbContext>(options => options
            .UseSqlServer(config.GetConnectionString("DefaultConnection")));
    }

    public static void ConfigureModelStateValidation(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(y => y.ErrorMessage)
                .ToArray();

                var errorResponse = new
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Messege = "Bad Request",
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            }
         );
    }
}

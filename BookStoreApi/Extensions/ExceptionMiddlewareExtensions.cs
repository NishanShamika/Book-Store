using BookStore.Application.Helpers.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace BookStore.Api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            if (contextFeature.Error is CustomeException customeException)
            {
                context.Response.StatusCode = (int)customeException.HttpStatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    context.Response.StatusCode,
                    Messege = customeException.CustomMessage,
                }));
            }
            else
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    context.Response.StatusCode,
                    Messege = contextFeature.Error.Message,
                }));
            }
        }
    }));
    }
}

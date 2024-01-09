using BookStore.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServices(builder.Configuration);
builder.Services.ConfigureModelStateValidation();
 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ConfigureExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//logging

//log in

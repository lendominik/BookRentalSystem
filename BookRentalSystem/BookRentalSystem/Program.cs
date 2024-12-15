using BookRentalSystem.Extensions;
using BookRentalSystem.Middlewares;
using Core.Models.Requests;
using BookRentalSystem.Validators;
using FluentValidation;
using Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddScoped<IValidator<AddBookRequest>, AddBookRequestValidator>();
builder.Services.AddScoped<IValidator<AddReviewRequest>, AddReviewRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using BookRentalSystem.Middlewares;
using BookRentalSystem.Models.Requests;
using BookRentalSystem.Persistence;
using BookRentalSystem.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration["ConnectionString"]
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddServices();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddScoped<IValidator<AddBookRequest>, AddBookRequestValidator>();
builder.Services.AddScoped<IValidator<AddReviewRequest>, AddReviewRequestValidator>();

var app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

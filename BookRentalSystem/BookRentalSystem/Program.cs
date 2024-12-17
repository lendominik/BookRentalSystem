using AutoMapper;
using BookRentalSystem.Extensions;
using BookRentalSystem.Mappings;
using BookRentalSystem.Middlewares;
using Infrastructure.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    var scope = provider.CreateScope();
    cfg.AddProfile(new BookRentalSystemMappingProfile());
}).CreateMapper());

builder.Services.AddControllers();

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();

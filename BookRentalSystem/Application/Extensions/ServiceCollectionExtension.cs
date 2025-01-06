using AutoMapper;
using Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.ApplicationUser;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserContext, UserContext>();

        services.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            var scope = provider.CreateScope();
            cfg.AddProfile(new BookRentalSystemMappingProfile());
        }).CreateMapper());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
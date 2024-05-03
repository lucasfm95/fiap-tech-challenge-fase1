using Fiap.TechChallenge.Application.Services;
using Fiap.TechChallenge.Domain.Repositories;
using Fiap.TechChallenge.Infrastructure.Repositories;

namespace Fiap.TechChallenge.Api;

public static class ConfigureDependencyInjection
{
    public static void RegisterRepositories(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IContactRepository, ContactRepository>();
    }
    
    public static void RegisterApplicationServices(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<ContactService>();
    }
}
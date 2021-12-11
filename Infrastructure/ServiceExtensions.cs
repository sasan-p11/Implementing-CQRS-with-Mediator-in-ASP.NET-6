using Domain.Data;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Migrations;

namespace Infrastructure;
public static class ServiceExtensions
{
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddSqlServer<DataContext>(configuration.GetConnectionString("DefaultConnection"));
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDataContext(configuration).AddUnitOfWork();
    }
}

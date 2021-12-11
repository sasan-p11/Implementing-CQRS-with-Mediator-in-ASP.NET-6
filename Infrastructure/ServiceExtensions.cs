using Domain.Data;
using Domain.Data.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Photos;
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
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPhotoAccessor, PhotoAccessor>();
        services.AddOptions();
        services.Configure<CloudinarySettings>(x => configuration.GetSection("cloudinary").Bind(x));
        //services.Configure<CloudinarySettings>(configuration.GetSection("cloudinary"));

        return services;
    }
}

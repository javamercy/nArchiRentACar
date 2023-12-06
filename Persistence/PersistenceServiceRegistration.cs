using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(
                "Server=localhost,1433;Database=RentACar;User Id=sa;Password=Gamefounder.23;TrustServerCertificate=True;"));

        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}

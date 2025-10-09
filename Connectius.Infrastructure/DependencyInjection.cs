using Connectius.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connectius.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration,
        IConfigurationSection section)
    {
        services.AddDbContext<UserDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<UserDbContext>();
        
        return services;
    }
}
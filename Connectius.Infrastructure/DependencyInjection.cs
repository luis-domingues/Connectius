using Connectius.Application.Common.Interfaces;
using Connectius.Domain.Common.Interfaces;
using Connectius.Domain.Interfaces;
using Connectius.Domain.Services;
using Connectius.Infrastructure.Data.Contexts;
using Connectius.Infrastructure.Data.Repositories;
using Connectius.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connectius.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IUserRepostory, UserRepository>();
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IEmailService, MockEmailService>();
        services.AddScoped<IAnalyticsService, MockAnalyticsService>();
        
        return services;
    }
}
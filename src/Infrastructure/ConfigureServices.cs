using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Application.User;
using Infrastructure.Services;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseNpgsql(
               configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<ILoggedInUserAccessor, HttpContextLoggedInUserAccessor>();

        return services;
    }

}
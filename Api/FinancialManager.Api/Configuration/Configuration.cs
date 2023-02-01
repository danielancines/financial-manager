using FinancialManager.Api.Services;
using FinancialManager.Data;
using FinancialManager.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinancialManager.Api.Configuration;

public static class Configuration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();

        var key = Encoding.ASCII.GetBytes(Secret.Random(30).ToString());
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<TokenService>();
        services.AddTransient<UserService>();

        return services;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<UserRepository>();
        services.AddTransient<ProductRepository>();
        return services;
    }

    public static IServiceCollection ConfigureContexts(this IServiceCollection services, string user, string dbPwd)
    {
        var envUser = Environment.GetEnvironmentVariable("DbUser");
        var envPwd = Environment.GetEnvironmentVariable("DbPWd");
        user = envUser ?? user;
        dbPwd = envPwd ?? dbPwd;
        services.AddDbContext<FinancialManagerDbContext>(options =>
        options
        .UseLazyLoadingProxies()
        .UseSqlServer($"Data Source=192.168.0.175,1433;Initial Catalog=PriceBuddyDb;User ID={user};Password={dbPwd};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

        return services;
    }
}

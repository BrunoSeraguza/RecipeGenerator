using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBookGenerator.Domain.Repositories.User;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;
using MyRecipeBookGenerator.Infrastructure.DataAccess;
using MyRecipeBookGenerator.Infrastructure.DataAccess.Repositories;
using MyRecipeBookGenerator.Infrastructure.Security.PasswordHashing;

namespace MyRecipeBookGenerator.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

        services.AddDbContext<MyRecipeBookDbContext>(options => 
        {
            options.UseSqlServer("asdsad");

        });

    }
}

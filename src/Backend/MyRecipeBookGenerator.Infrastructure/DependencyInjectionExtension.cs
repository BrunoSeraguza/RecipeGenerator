using Microsoft.Extensions.DependencyInjection;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;
using MyRecipeBookGenerator.Infrastructure.Security.PasswordHashing;

namespace MyRecipeBookGenerator.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
    }
}

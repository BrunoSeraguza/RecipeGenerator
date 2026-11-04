using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBookGenerator.Domain.Repositories.User;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;
using MyRecipeBookGenerator.Infrastructure.DataAccess;
using MyRecipeBookGenerator.Infrastructure.DataAccess.Repositories;
using MyRecipeBookGenerator.Infrastructure.Security.PasswordHashing;

namespace MyRecipeBookGenerator.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddDbContext<MyRecipeBookDbContext>(options => 
        {
            var connection = configuration.GetConnectionString("DbConnection");
            options.UseSqlServer(connection);

        });

    }
}

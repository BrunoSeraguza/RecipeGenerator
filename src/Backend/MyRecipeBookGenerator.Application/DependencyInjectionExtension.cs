using Microsoft.Extensions.DependencyInjection;
using MyRecipeBookGenerator.Application.UseCases.User.Register;

namespace MyRecipeBookGenerator.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication( this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }

}

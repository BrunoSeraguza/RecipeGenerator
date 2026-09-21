using Microsoft.Extensions.DependencyInjection;
using MyRecipeBookGenerator.Application.UseCases.User.Register;

namespace MyRecipeBookGenerator.Application;

public class DependencyInjectionExtension
{
    public static void AddApplication(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }

}

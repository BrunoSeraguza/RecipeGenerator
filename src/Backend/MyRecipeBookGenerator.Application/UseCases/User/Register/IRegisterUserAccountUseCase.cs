using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    Task Execute(RequestRegisterUserAccountJson request);
}

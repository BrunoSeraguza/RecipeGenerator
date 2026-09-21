using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    void Execute(RequestRegisterUserAccountJson request);
}

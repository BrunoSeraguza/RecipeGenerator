using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Communication.Response;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request);
}

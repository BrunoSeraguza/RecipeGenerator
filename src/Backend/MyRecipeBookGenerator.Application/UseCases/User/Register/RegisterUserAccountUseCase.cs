using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase
{
    public void Execute(RequestRegisterUserAccountJson request)
    {
        var validate = new RegisterUserAccountValidator();

        var result =  validate.Validate(request);

    }
}

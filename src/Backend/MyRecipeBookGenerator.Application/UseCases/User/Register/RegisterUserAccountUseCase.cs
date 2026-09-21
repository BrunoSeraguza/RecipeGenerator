using Mapster;
using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;
using MyRecipeBookGenerator.Exception.ExceptionsBase;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    public RegisterUserAccountUseCase(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void Execute(RequestRegisterUserAccountJson request)
    {

        ValidadeAndThrowOnFailure(request);
        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHasher.HashPassword(request.Password);
    }

    private static void ValidadeAndThrowOnFailure(RequestRegisterUserAccountJson request)
    {
        var validate = new RegisterUserAccountValidator();

        var result = validate.Validate(request);

        if (!result.IsValid)
        {
            var errorsMessage = result.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorOnValidatorException(errorsMessage);
        }
    }

}

using System.Security.AccessControl;
using FluentValidation.Results;
using Mapster;
using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Communication.Response;
using MyRecipeBookGenerator.Domain.Repositories;
using MyRecipeBookGenerator.Domain.Repositories.User;
using MyRecipeBookGenerator.Domain.Security.PasswordHasher;
using MyRecipeBookGenerator.Exception;
using MyRecipeBookGenerator.Exception.ExceptionsBase;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserAccountUseCase(
        IPasswordHasher passwordHasher,
        IUserWriteOnlyRepository userWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        IUserReadOnlyRepository userReadOnlyRepository
        )
    {
        _passwordHasher = passwordHasher;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _userReadOnlyRepository = userReadOnlyRepository;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserAccountJson request)
    {


        await ValidadeAndThrowOnFailure(request);
        var user = request.Adapt<Domain.Entities.Users>();

        user.Password = _passwordHasher.HashPassword(request.Password);

        await _userWriteOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
            Token = new ResponseTokenJson()
        };
    }

    private async Task ValidadeAndThrowOnFailure(RequestRegisterUserAccountJson request)
    {
        var validate = new RegisterUserAccountValidator();

        var result = validate.Validate(request);

        var emailExist = await _userReadOnlyRepository.VerifyExistActiveEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ExeptionsMessageResource.VALIDATION_EMAIL_ALREADY_EXIST));
        }


        if (!result.IsValid)
        {
            var errorsMessage = result.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorOnValidatorException(errorsMessage);
        }
    }

}

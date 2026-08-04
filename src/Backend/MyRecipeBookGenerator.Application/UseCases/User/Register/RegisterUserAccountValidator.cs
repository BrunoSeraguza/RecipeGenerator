using FluentValidation;
using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Exception;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

internal class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ExeptionsMessageResource.VALIDATION_NAME_REQUIRED);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ExeptionsMessageResource.VALIDATION_PASSWORD_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ExeptionsMessageResource.VALIDATION_EMAIL_REQUIRED);

        When(user => !string.IsNullOrWhiteSpace(user.Email), () =>
        {
            RuleFor(user => user.Password).EmailAddress().WithMessage(ExeptionsMessageResource.VALIDATION_EMAIL_VALID);
        });
    }
}

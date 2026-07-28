using FluentValidation;
using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Application.UseCases.User.Register;

internal class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("O Nome não pode ser vazio");
        RuleFor(user => user.Password).NotEmpty().WithMessage("Senha nao pode ser vazia");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email nao pode ser vazio");

        When(user => !string.IsNullOrWhiteSpace(user.Email), () =>
        {
            RuleFor(user => user.Password).EmailAddress().WithMessage("Email deve ser um email valido");
        });
    }
}

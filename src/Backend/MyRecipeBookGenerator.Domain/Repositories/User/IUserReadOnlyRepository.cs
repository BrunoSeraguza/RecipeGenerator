namespace MyRecipeBookGenerator.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{

    Task<bool> VerifyExistActiveEmail(string email);
}

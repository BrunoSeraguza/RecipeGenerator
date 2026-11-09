namespace MyRecipeBookGenerator.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    Task Add(Entities.Users user);
}

namespace MyRecipeBookGenerator.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}

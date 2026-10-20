using MyRecipeBookGenerator.Domain.Entities;
using MyRecipeBookGenerator.Domain.Repositories.User;

namespace MyRecipeBookGenerator.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepository : IUserWriteOnlyRepository
{
    private readonly MyRecipeBookDbContext _context;

    public UserRepository(MyRecipeBookDbContext context)
    {
        _context = context;         
    }

    public async Task Add(User user)
    {
         await _context.Users.AddAsync(user);
    }

}

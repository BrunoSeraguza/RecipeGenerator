using Microsoft.EntityFrameworkCore;
using MyRecipeBookGenerator.Domain.Entities;
using MyRecipeBookGenerator.Domain.Repositories.User;

namespace MyRecipeBookGenerator.Infrastructure.DataAccess.Repositories;

internal sealed class UserRepository : IUserWriteOnlyRepository , IUserReadOnlyRepository
{
    private readonly MyRecipeBookDbContext _context;

    public UserRepository(MyRecipeBookDbContext context)
    {
        _context = context;         
    }

    public async Task Add(Users user)
    {
         await _context.Users.AddAsync(user);
    }

    public async Task<bool> VerifyExistActiveEmail(string email)
    {
        return  await _context.Users.AnyAsync(user => user.Active && user.Email.Equals(email));
    }
}

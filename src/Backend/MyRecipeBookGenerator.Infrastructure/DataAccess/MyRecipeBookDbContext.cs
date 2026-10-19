using Microsoft.EntityFrameworkCore;
using MyRecipeBookGenerator.Domain.Entities;

namespace MyRecipeBookGenerator.Infrastructure.DataAccess
{
    internal class MyRecipeBookDbContext : DbContext
    {
        public MyRecipeBookDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


        public DbSet<User> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Ado_Clic.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext (DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ado_Clic.Models.User> User => Set<Ado_Clic.Models.User>();
    }
}
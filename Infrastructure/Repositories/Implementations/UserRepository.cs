using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataContext;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Infrastructure.Repositories.Implementations
{
    public class UserRepository(AdoclicDataContext context) : IUserRepository
    {
        private readonly AdoclicDataContext _context = context;

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}

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
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetProfileDataByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Address)
                .Include(u => u.EmergencyContact)
                .Include(u => u.UserVolunteerInterests)
                .Include(u => u.InterventionTypes)
                .FirstAsync(u => u.Email == email);
        }
    }
}

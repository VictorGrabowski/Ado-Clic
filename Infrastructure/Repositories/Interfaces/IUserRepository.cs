using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByEmailAsync(string email);

        public Task<User> GetProfileDataByEmailAsync(string email);

        public Task<List<User>> GetAllUsersAsync();
    }
}

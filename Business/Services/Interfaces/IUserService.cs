using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Responses;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string?> AuthenticateAsync(string email, string password);

        public Task<UserProfileData> GetUserProfileDataByEmailAsync(string email);

        public Task<List<UserListData>> GetAllUsersAsListDataAsync();
    }
}

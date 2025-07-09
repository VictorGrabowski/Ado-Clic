using Business.Responses;
using Model.Model;

namespace Business.Mappers
{
    internal static class UserMapper
    {
        internal static UserProfileData ToProfileData(this User user)
            => new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthTimestamp = user.BirthTimestamp
            };
    }
}

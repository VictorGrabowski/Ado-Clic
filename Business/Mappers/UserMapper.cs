using Business.Responses;
using Model.Model;

namespace Business.Mappers
{
    internal static class UserMapper
    {
        internal static UserProfileData ToProfileData(this User user)
        {
            List<InterventionTypeData> typeData = user.InterventionTypes?.Select(it => new InterventionTypeData
            {
                Id = it.Id,
                Name = it.Name
            })?.ToList() ?? [];

            UserProfileData userProfileData = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthTimestamp = user.BirthTimestamp,
                InterventionTypes = typeData
            };

            return userProfileData;
        }

        internal static UserListData ToListData(this User user)
            => new()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role?.Name ?? "Unknown"
            };
    }
}

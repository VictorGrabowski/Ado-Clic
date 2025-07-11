using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Mappers;
using Business.Requests;
using Business.Responses;
using Business.Services.Interfaces;
using Infrastructure.Repositories.Interfaces;
using Model.Model;

namespace Business.Services.Implementations
{
    public class InterventionService(IInterventionRepository repository, IUserService userService) : IInterventionService
    {
        private readonly IInterventionRepository _repository = repository;
        private readonly IUserService _userService = userService;

        public async Task<List<InterventionType>> GetInterventionTypesAsync()
        {
            return await _repository.GetInterventionTypesAsync();
        }

        public async Task<List<InterventionRequestData>> GetInterventionRequestDataByUserAsync(string userEmail)
        {
            UserProfileData user = await _userService.GetUserProfileDataByEmailAsync(userEmail);

            List<InterventionRequest> requests = await _repository.GetByUserAsync(user.Id);

            return requests.Select(request => request.ToData()).ToList();
        }

        public async Task<List<InterventionRequestData>> GetNotAcceptedByTypeAsync(long[] ids)
        {
            List<InterventionRequest> requests = await _repository.GetNotAcceptedByTypesAsync(ids);

            return requests.Select(request => request.ToData()).ToList();
        }

        public async Task CreateInterventionAsync(InterventionRequestCreation request, string userEmail)
        {
            UserProfileData user = await _userService.GetUserProfileDataByEmailAsync(userEmail);

            InterventionRequest interventionRequest = request.ToDao(user.Id);

            await _repository.InsertOneAsync(interventionRequest);
        }

        public async Task DeleteOneUserTypeAsync(long userId, long interventionTypeId)
        {
            await _repository.DeleteOneUserTypeAsync(userId, interventionTypeId);
        }
    }
}

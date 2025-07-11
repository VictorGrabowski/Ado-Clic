using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Requests;
using Model.Model;

namespace Business.Services.Interfaces
{
    public interface IInterventionService
    {
        public Task<List<InterventionType>> GetInterventionTypesAsync();

        public Task<List<InterventionRequestData>> GetInterventionRequestDataByUserAsync(string userEmail);

        public Task<List<InterventionRequestData>> GetNotAcceptedByTypeAsync(long[] ids);

        public Task CreateInterventionAsync(InterventionRequestCreation request, string userEmail);

        public Task DeleteOneUserTypeAsync(long userId, long interventionTypeId);
    }
}

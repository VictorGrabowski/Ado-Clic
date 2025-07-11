using Model.Model;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IInterventionRepository
    {
        public Task<List<InterventionType>> GetInterventionTypesAsync();

        public Task<List<InterventionRequest>> GetByUserAsync(long userId);

        public Task<List<InterventionRequest>> GetNotAcceptedByTypesAsync(long[] ids);

        public Task InsertOneAsync(InterventionRequest request);

        public Task DeleteOneUserTypeAsync(long userId, long typeId);
    }
}

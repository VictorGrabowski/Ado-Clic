using Infrastructure.DataContext;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace Infrastructure.Repositories.Implementations
{
    public class InterventionRepository(AdoclicDataContext dataContext) : IInterventionRepository
    {
        private readonly AdoclicDataContext _context = dataContext;

        public async Task<List<InterventionType>> GetInterventionTypesAsync()
        {
            return await _context.InterventionTypes.ToListAsync();
        }

        public async Task<List<InterventionRequest>> GetByUserAsync(long userId)
        {
            return await _context.InterventionRequests
                .Include(i => i.InterventionType)
                .Where(request => request.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<InterventionRequest>> GetNotAcceptedByTypesAsync(long[] ids)
        {
            return await _context.InterventionRequests
                .Where(request => ids.Contains(request.InterventionTypeId))
                .Where(request => !_context.InterventionActivities
                    .Where(activity => activity.InterventionId == request.Id)
                    .Any(activity => activity.AbandonedTimestamp == null))
                .ToListAsync();
        }

        public async Task InsertOneAsync(InterventionRequest request)
        {
            await _context.InterventionRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOneUserTypeAsync(long userId, long typeId)
        {
            var user = await _context.Users
                .Include(u => u.InterventionTypes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                var interventionType = user.InterventionTypes?.FirstOrDefault(it => it.Id == typeId);
                
                if (interventionType != null)
                {
                    user.InterventionTypes?.Remove(interventionType);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}

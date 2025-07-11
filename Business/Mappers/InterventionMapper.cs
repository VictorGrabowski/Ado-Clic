using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Business.Requests;
using Model.Model;

namespace Business.Mappers
{
    internal static class InterventionMapper
    {
        internal static InterventionRequest ToDao(this InterventionRequestCreation request, long userId)
        {
            InterventionRequest interventionRequest = new()
            {
                Description = request.Description ?? "",
                InterventionTypeId = request.InterventionTypeId ?? throw new ArgumentNullException(nameof(request.InterventionTypeId)),
                IsActive = true,
                IsDraft = false,
                Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                Title = request.Name ?? "",
                UserId = userId
            };

            return interventionRequest;
        }

        internal static InterventionRequestData ToData(this InterventionRequest request)
            => new()
            {
                DateTime = DateTimeOffset.FromUnixTimeSeconds(request.Timestamp).DateTime,
                Description = request.Description,
                Id = request.Id ?? throw new ArgumentNullException(nameof(request.Id)),
                Name = request.Title,
                InterventionTypeName = request.InterventionType?.Name ?? "Unknown"
            };
    }
}

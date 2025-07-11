using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses
{
    public class UserProfileData
    {
        public required long Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required long BirthTimestamp { get; set; }
        public required List<InterventionTypeData> InterventionTypes { get; set; }
    }

    public class InterventionTypeData
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
    }
}

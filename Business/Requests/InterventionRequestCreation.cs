using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests
{
    public class InterventionRequestCreation
    {
        public long? InterventionTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}

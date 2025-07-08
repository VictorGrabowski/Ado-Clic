using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class InterventionActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required long VolunteerId { get; set; }
        public required long InterventionId { get; set; }
        public required long AcceptedTimestamp { get; set; }
        public long? AbandonedTimestamp { get; set; }
        public long? FinishedTimestamp { get; set; }
        public int? UserRating { get; set; }
        public string? UserRatingComment { get; set; }

        public required User Volunteer { get; set; }
        public required InterventionRequest Intervention { get; set; }

        public List<InterventionChatMessage>? Messages { get; set; }
    }
}

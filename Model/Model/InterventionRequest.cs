using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class InterventionRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required long InterventionTypeId { get; set; }
        public required long Timestamp { get; set; }
        public required bool IsDraft { get; set; }
        public required bool IsActive { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public required User User { get; set; }
        public required InterventionType InterventionType { get; set; }
        public InterventionAddress? Address { get; set; }

        public List<InterventionActivity>? Activities { get; set; }
    }
}

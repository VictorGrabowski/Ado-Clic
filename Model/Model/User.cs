using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required long RoleId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PasswordHash { get; set; }
        public required long BirthTimestamp { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ExtraNeeds { get; set; }
        public string? Notes { get; set; }
        public string? PhotoPath { get; set; }

        public required UserRole Role { get; set; }
        public UserAddress? Address { get; set; }
        public UserEmergencyContact? EmergencyContact { get; set; }
        public List<UserVolunteerInterest>? UserVolunteerInterests { get; set; }
        public EmailVerificationToken? VerificationToken { get; set; }

        public List<UserBlacklist>? BlacklistedUsers { get; set; }
        public List<InterventionType>? InterventionTypes { get; set; }
        public List<InterventionRequest>? InterventionRequests { get; set; }
    }
}

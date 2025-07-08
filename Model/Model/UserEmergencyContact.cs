using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class UserEmergencyContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Telephone { get; set; }

        public required User User { get; set; }
    }
}

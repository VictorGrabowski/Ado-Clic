using System.ComponentModel.DataAnnotations;
using Ado_Clic.Models.Enums;

namespace Ado_Clic.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string? PName { get; set; }
        [Required, StringLength(15)]
        public string? LName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public UserType? UserType { get; set; } 
    }
}

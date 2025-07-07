using System.ComponentModel.DataAnnotations;

namespace Ado_Clic.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string? PName { get; set; }
        [Required, StringLength(15)]
        public string? LName { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
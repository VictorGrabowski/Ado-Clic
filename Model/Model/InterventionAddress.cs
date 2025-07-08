using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class InterventionAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required long Id { get; set; }
        public required long InterventionId { get; set; }
        public required string PostalCode { get; set; }
        public required string Town { get; set; }
        public required string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        public required InterventionRequest Intervention { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class EmailVerificationToken
    {
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required string Token { get; set; }
        public required long ExpiryTimestamp { get; set; }

        public required User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class UserBlacklist
    {
        public required long Id { get; set; }
        public required long UserId { get; set; }
        public required long BlacklistedUserId { get; set; }
        public required long Timestamp { get; set; }

        public required User User { get; set; }
        public required User BlacklistedUser { get; set; }
    }
}

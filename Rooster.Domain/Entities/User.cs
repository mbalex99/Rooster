using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.Domain.Entities
{
    public abstract class User
    {
        public int UserId { get; set; }
        public Email Email { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}

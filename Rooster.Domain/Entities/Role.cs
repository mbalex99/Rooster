using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } 
    }
}

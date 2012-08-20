using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public DateTime DateModified { get; set; }
        public string Content { get; set; }
    }
}

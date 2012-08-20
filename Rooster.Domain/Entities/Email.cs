using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.Domain.Entities
{
    public class Email
    {
        public int EmailId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsUnsubscribed { get; set; } 

        public Email()
        {
            
        }

        public Email(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            return EmailAddress;
        }
    }
}

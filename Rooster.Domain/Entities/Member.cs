using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Rooster.Security;

namespace Rooster.Domain.Entities
{
    [Table("Members")]
    public class Member : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsApproved { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Role> Roles { get; set; }  

        public byte[] Salt { get; private set; }
        public byte[] PasswordHash { get; private set; }

        [NotMapped]
        public string Password
        {
            set
            {
                this.Salt = Security.SaltedHash.GenerateSalt();
                this.PasswordHash = Security.SaltedHash.GenerateSaltedHash(value, this.Salt);
            }
        }

        public bool ValidatePassword(string plaintextPassword)
        {
            if (this.Email == null)
            {
                return false;
            }

            if (this.Salt == null || this.PasswordHash == null)
            {
                return false;
            }

            return SaltedHash.IsPasswordValid(plaintextPassword, this.Salt, this.PasswordHash);
        }

    }
}

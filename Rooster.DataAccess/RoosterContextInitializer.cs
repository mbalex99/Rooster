using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess
{
    public class RoosterContextInitializer : DropCreateDatabaseAlways<RoosterContext>
    {
        protected override void Seed(RoosterContext context)
        {
            var adminRole = new Role() {Name = "Admin"};
            var regularRole = new Role() { Name = "Editor" };

            context.Roles.Add(adminRole);
            context.Roles.Add(regularRole);
            context.Commit();

            var adminUser1 = new Member()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = new Email("john.doe@rooster.com"),
                    Password = "roosterisawesome",
                    Roles = new Collection<Role> {adminRole, regularRole},
                    DateModified = DateTime.Now,
                    LastActivityDate = DateTime.Now,
                    IsApproved = true
                };

            var adminUser2 = new Member()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = new Email("jane.doe@rooster.com"),
                Password = "roosterisawesome",
                Roles = new Collection<Role> { adminRole, regularRole },
                DateModified = DateTime.Now,
                LastActivityDate = DateTime.Now,
                IsApproved = true
            };

            var regularUser1 = new Member()
            {
                FirstName = "George",
                LastName = "Washington",
                Email = new Email("george.washington@rooster.com"),
                Password = "roosterisawesome",
                Roles = new Collection<Role> { regularRole },
                DateModified = DateTime.Now,
                LastActivityDate = DateTime.Now,
                IsApproved = true
            };

            var regularUser2 = new Member()
            {
                FirstName = "Mary",
                LastName = "Smith",
                Email = new Email("mary.smith@rooster.com"),
                Password = "roosterisawesome",
                Roles = new Collection<Role> { regularRole },
                DateModified = DateTime.Now,
                LastActivityDate = DateTime.Now,
                IsApproved = true
            };

            context.Users.Add(adminUser1);
            context.Users.Add(adminUser2);
            context.Users.Add(regularUser1);
            context.Users.Add(regularUser2);
            context.Commit();


        }

    }
}

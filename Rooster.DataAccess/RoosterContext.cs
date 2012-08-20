using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess
{
    public class RoosterContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        
        public IQueryable<T> Find<T>() where T: class
        {
            return this.Set<T>();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public void Rollback()
        {
            this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

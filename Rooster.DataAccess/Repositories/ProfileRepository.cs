using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess.Repositories
{
    public class ProfileRepository:RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }
    }

    public interface IProfileRepository: IRepository<Profile>
    {
        
    }
}

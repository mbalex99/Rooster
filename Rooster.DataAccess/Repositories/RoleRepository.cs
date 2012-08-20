using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess.Repositories
{
    public class RoleRepository: RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }
    }

    public interface IRoleRepository: IRepository<Role>
    {
        
    }
}

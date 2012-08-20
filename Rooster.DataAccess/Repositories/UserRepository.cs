using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }
    }

    public interface IUserRepository: IRepository<User>
    {
        
    }
}

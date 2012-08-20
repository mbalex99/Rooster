using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess.Repositories
{
    public class EmailRepository:RepositoryBase<Email>, IEmailRepository
    {
        public EmailRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }
    }

    public interface IEmailRepository: IRepository<Email>
    {
        
    }
}

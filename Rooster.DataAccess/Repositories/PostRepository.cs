using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rooster.DataAccess.Infrastructure;
using Rooster.Domain.Entities;

namespace Rooster.DataAccess.Repositories
{
    public class PostRepository:RepositoryBase<Post>, IPostRepostiory
    {
        public PostRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {
            
        }
    }

    public interface IPostRepostiory: IRepository<Post>
    {
        
    }
}

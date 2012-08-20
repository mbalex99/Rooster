using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Rollback();
        void Commit();
    }
}

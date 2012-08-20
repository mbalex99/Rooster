using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.DataAccess.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private RoosterContext _dataContext;
        
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected RoosterContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        public void Rollback()
        {
            DataContext.Rollback();
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}

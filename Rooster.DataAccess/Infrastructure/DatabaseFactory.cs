using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rooster.DataAccess.Infrastructure
{
    public interface IDatabaseFactory
    {
        RoosterContext Get();
    }

    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private RoosterContext _context;

        public RoosterContext Get()
        {
            return _context ?? (_context = new RoosterContext());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}

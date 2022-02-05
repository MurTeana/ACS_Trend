using ACS_Trend.DataAccess.EFCore.Repositories;
using ACS_Trend.Domain.Interfaces;

namespace ACS_Trend.DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Units = new UnitRepository(_context);
            // other repos
        }
        public IUnitRepository Units { get; private set; }
        // other repos
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

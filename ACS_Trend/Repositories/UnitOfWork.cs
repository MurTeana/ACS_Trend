using ACS_Trend.Interfaces;
using ACS_Trend.Models.DB.Context;

namespace ACS_Trend.Repositories
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

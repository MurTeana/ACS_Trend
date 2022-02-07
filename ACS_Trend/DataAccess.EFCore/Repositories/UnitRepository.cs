using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNewUnit(Unit unit)
        {
            _context.Set<Unit>().Add(unit);
            _context.SaveChanges();
        }
        public IEnumerable<Unit> GetAllUnits()
        {
            return _context.Set<Unit>().ToList(); ;
        }
    }
}

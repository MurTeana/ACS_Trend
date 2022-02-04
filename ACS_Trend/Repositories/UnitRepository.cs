using ACS_Trend.Interfaces;
using ACS_Trend.Models.DB.Context;
using ACS_Trend.Models.DB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Unit> GetAllUnits()
        {
            return _context.Set<Unit>().ToList(); ;
        }
    }
}

using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class TrendPointRepository : GenericRepository<TrendPoint>, ITrendPointRepository
    {
        public TrendPointRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<TrendPoint> GetAllTrendPoints()
        {
            return _context.Set<TrendPoint>().ToList(); ;
        }
    }
}

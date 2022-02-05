using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class TrendRepository : GenericRepository<Trend>, ITrendRepository
    {
        public TrendRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Trend> GetAllTrends()
        {
            return _context.Set<Trend>().ToList(); ;
        }
    }
}

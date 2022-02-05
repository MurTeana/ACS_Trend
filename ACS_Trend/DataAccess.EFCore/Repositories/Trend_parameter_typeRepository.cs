using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameter_typeRepository : GenericRepository<Trend_parameter_type>, ITrend_parameter_typeRepository
    {
        public Trend_parameter_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Trend_parameter_type> GetAllTrend_parameter_types()
        {
            return _context.Set<Trend_parameter_type>().ToList(); ;
        }
    }
}

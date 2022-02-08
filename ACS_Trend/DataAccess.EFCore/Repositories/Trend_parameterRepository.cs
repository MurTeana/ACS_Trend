using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameterRepository : GenericRepository<Trend_parameter>, ITrend_parameterRepository
    {
        public Trend_parameterRepository(ApplicationContext context) : base(context)
        {
        }
        public void AddNewTrend_parameter(Trend_parameter trend_Parameter)
        {
            _context.Set<Trend_parameter>().Add(trend_Parameter);
            _context.SaveChanges();
        }
        public List<Trend_parameter> GetAllTrend_parameters()
        {
            return _context.Set<Trend_parameter>().ToList();
        }
    }
}

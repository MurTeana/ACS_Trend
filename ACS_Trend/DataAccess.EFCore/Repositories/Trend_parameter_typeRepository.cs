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
        public void AddNewTrend_parameter_type(Trend_parameter_type trend_Parameter_Type)
        {
            _context.Set<Trend_parameter_type>().Add(trend_Parameter_Type);
            _context.SaveChanges();
        }
        public List<Trend_parameter_type> GetAllTrend_parameter_types()
        {
            return _context.Set<Trend_parameter_type>().ToList();
        }
    }
}

using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Station_typeRepository : GenericRepository<Station_type>, IStation_typeRepository
    {
        public Station_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Station_type> GetAllStation_types()
        {
            return _context.Set<Station_type>().ToList(); ;
        }
    }
}

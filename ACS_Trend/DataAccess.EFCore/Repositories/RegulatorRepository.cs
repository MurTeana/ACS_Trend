using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class RegulatorRepository : GenericRepository<Regulator>, IRegulatorRepository
    {
        public RegulatorRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Regulator> GetAllRegulators()
        {
            return _context.Set<Regulator>().ToList(); ;
        }
    }
}

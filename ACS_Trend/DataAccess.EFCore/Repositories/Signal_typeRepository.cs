using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Signal_typeRepository : GenericRepository<Signal_type>, ISignal_typeRepository
    {
        public Signal_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Signal_type> GetAllSignal_types()
        {
            return _context.Set<Signal_type>().ToList(); ;
        }
    }
}

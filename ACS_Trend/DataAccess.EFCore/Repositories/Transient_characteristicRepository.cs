using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Transient_characteristicRepository : GenericRepository<Transient_characteristic>, ITransient_characteristicRepository
    {
        public Transient_characteristicRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Transient_characteristic> GetAllTransient_characteristics()
        {
            return _context.Set<Transient_characteristic>().ToList(); ;
        }
    }
}

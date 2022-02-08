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

        public void AddNewStation_type(Station_type station_Type)
        {
            _context.Set<Station_type>().Add(station_Type);
            _context.SaveChanges();
        }
        public List<Station_type> GetAllStation_types()
        {
            return _context.Set<Station_type>().ToList();
        }
    }
}

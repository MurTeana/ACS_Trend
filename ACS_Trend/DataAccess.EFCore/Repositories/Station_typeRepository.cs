using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Station_typeRepository : GenericRepository<Station_typeViewModel>, IStation_typeRepository
    {
        public Station_typeRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewStation_type(Station_typeViewModel model)
        {
            Station_type st_t = new Station_type()
            {
                StationType = model.StationType
            };

            _context.Station_types.Add(st_t);
            _context.SaveChanges();

            return st_t.ID_Station_type;
        }
        public List<Station_type> GetAllStation_types()
        {
            return _context.Set<Station_type>().ToList();
        }
    }
}

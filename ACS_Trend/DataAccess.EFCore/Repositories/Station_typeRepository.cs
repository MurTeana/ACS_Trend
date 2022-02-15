using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Station_typeRepository : GenericRepository<Station_type>, IStation_typeRepository
    {
        public Station_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public int AddNewStation_type(Station_type model)
        {
            _context.Station_types.Add(model);
            _context.SaveChanges();

            return model.ID_Station_type;
        }

        public bool DeleteStation_type(int id)
        {
            var Station_type = _context.Station_types.FirstOrDefault(x => x.ID_Station_type == id);

            if (Station_type != null)
            {
                _context.Station_types.Remove(Station_type);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Station_type> GetAllStation_types()
        {
            var result = _context.Station_types
                .Select(x => new Station_type()
                {
                    ID_Station_type = x.ID_Station_type,
                    Station_type_name = x.Station_type_name,
                }).ToList();

            return result;
        }

        public Station_type GetStation_type(int id)
        {
            var result = _context.Station_types
                .Where(x => x.ID_Station_type == id)
                .Select(x => new Station_type()
                {
                    ID_Station_type = x.ID_Station_type,
                    Station_type_name = x.Station_type_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateStation_type(int id, Station_type model)
        {
            var Station_type = _context.Station_types.FirstOrDefault(x => x.ID_Station_type == id);

            if (Station_type != null)
            {
                Station_type.Station_type_name = model.Station_type_name;
            }

            _context.SaveChanges();
            return true;
        }

    }
}

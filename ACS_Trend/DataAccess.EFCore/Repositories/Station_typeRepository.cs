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
        public List<Station_typeViewModel> GetAllStation_types()
        {
            var result = _context.Station_types
            .Select(x => new Station_typeViewModel()
            {
                ID_Station_type = x.ID_Station_type,
                StationType = x.StationType,
            }).ToList();

            return result;
        }

        public Station_typeViewModel GetStation_Type(int id)
        {
            var result = _context.Station_types
                .Where(x => x.ID_Station_type == id)
                .Select(x => new Station_typeViewModel()
                {
                    ID_Station_type = x.ID_Station_type,
                    StationType = x.StationType
                }).FirstOrDefault();
           
            return result;
        }

        public bool UpdateStation_Type(int id, Station_typeViewModel model)
        {
            var st_t = _context.Station_types.FirstOrDefault(x => x.ID_Station_type == id);

            if(st_t != null)
            {
                st_t.StationType = model.StationType;
            }

            _context.SaveChanges();
            return true;
        }

        public bool DeleteStation_Type(int id)
        {
            var st_t = _context.Station_types.FirstOrDefault(x => x.ID_Station_type == id);

            if (st_t != null)
            {
                _context.Station_types.Remove(st_t);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

    }
}

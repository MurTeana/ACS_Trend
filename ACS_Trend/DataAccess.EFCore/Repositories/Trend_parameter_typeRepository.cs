using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameter_typeRepository : GenericRepository<Trend_parameter_type>, ITrend_parameter_typeRepository
    {
        public Trend_parameter_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public int AddNewTrend_parameter_type(Trend_parameter_type model)
        {
            Trend_parameter_type Trend_parameter_type = new Trend_parameter_type()
            {
                Trend_parameter_type_name = model.Trend_parameter_type_name
            };

            _context.Trend_parameter_types.Add(Trend_parameter_type);
            _context.SaveChanges();

            return Trend_parameter_type.ID_Trend_parameter_type;
        }

        public bool DeleteTrend_parameter_type(int id)
        {
            var Trend_parameter_type = _context.Trend_parameter_types.FirstOrDefault(x => x.ID_Trend_parameter_type == id);

            if (Trend_parameter_type != null)
            {
                _context.Trend_parameter_types.Remove(Trend_parameter_type);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Trend_parameter_type> GetAllTrend_parameter_types()
        {
            var result = _context.Trend_parameter_types
                .Select(x => new Trend_parameter_type()
                {
                    ID_Trend_parameter_type = x.ID_Trend_parameter_type,
                    Trend_parameter_type_name = x.Trend_parameter_type_name,
                }).ToList();

            return result;
        }

        public Trend_parameter_type GetTrend_parameter_type(int id)
        {
            var result = _context.Trend_parameter_types
                .Where(x => x.ID_Trend_parameter_type == id)
                .Select(x => new Trend_parameter_type()
                {
                    ID_Trend_parameter_type = x.ID_Trend_parameter_type,
                    Trend_parameter_type_name = x.Trend_parameter_type_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTrend_parameter_type(int id, Trend_parameter_type model)
        {
            var Trend_parameter_type = _context.Trend_parameter_types.FirstOrDefault(x => x.ID_Trend_parameter_type == id);

            if (Trend_parameter_type != null)
            {
                Trend_parameter_type.Trend_parameter_type_name = model.Trend_parameter_type_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

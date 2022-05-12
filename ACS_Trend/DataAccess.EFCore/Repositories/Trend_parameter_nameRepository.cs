using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameter_nameRepository : GenericRepository<Trend_parameter_name>, ITrend_parameter_nameRepository
    {
        public Trend_parameter_nameRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewTrend_parameter_name(Trend_parameter_name model)
        {
            _context.Trend_parameter_names.Add(model);
            _context.SaveChanges();

            return model.ID_Trend_parameter_name;
        }

        public bool DeleteTrend_parameter_name(int id)
        {
            var Trend_parameter_name = _context.Trend_parameter_names.FirstOrDefault(x => x.ID_Trend_parameter_name == id);

            if (Trend_parameter_name != null)
            {
                _context.Trend_parameter_names.Remove(Trend_parameter_name);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Trend_parameter_name> GetAllTrend_parameter_names()
        {
            var result = _context.Trend_parameter_names
                .Select(x => new Trend_parameter_name()
                {
                    ID_Trend_parameter_name = x.ID_Trend_parameter_name,
                    Trend_parameter_name_val = x.Trend_parameter_name_val,
                }).ToList();

            return result;
        }

        public Trend_parameter_name GetTrend_parameter_name(int id)
        {
            var result = _context.Trend_parameter_names
                .Where(x => x.ID_Trend_parameter_name == id)
                .Select(x => new Trend_parameter_name()
                {
                    ID_Trend_parameter_name = x.ID_Trend_parameter_name,
                    Trend_parameter_name_val = x.Trend_parameter_name_val
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTrend_parameter_name(int id, Trend_parameter_name model)
        {
            var Trend_parameter_name = _context.Trend_parameter_names.FirstOrDefault(x => x.ID_Trend_parameter_name == id);

            if (Trend_parameter_name != null)
            {
                Trend_parameter_name.Trend_parameter_name_val = model.Trend_parameter_name_val;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

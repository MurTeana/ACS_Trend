using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameterRepository : GenericRepository<Trend_parameterViewModel>, ITrend_parameterRepository
    {
        public Trend_parameterRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewTrend_parameter(Trend_parameterViewModel model)
        {
            Trend_parameter Trend_parameter = new Trend_parameter()
            {
                Trend_parameter_name = model.Trend_parameter_name
            };

            _context.Trend_parameters.Add(Trend_parameter);
            _context.SaveChanges();

            return Trend_parameter.ID_Trend_parameter;
        }

        public bool DeleteTrend_parameter(int id)
        {
            var Trend_parameter = _context.Trend_parameters.FirstOrDefault(x => x.ID_Trend_parameter == id);

            if (Trend_parameter != null)
            {
                _context.Trend_parameters.Remove(Trend_parameter);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Trend_parameterViewModel> GetAllTrend_parameters()
        {
            var result = _context.Trend_parameters
                .Select(x => new Trend_parameterViewModel()
                {
                    ID_Trend_parameter = x.ID_Trend_parameter,
                    Trend_parameter_name = x.Trend_parameter_name,
                }).ToList();

            return result;
        }

        public Trend_parameterViewModel GetTrend_parameter(int id)
        {
            var result = _context.Trend_parameters
                .Where(x => x.ID_Trend_parameter == id)
                .Select(x => new Trend_parameterViewModel()
                {
                    ID_Trend_parameter = x.ID_Trend_parameter,
                    Trend_parameter_name = x.Trend_parameter_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTrend_parameter(int id, Trend_parameterViewModel model)
        {
            var Trend_parameter = _context.Trend_parameters.FirstOrDefault(x => x.ID_Trend_parameter == id);

            if (Trend_parameter != null)
            {
                Trend_parameter.Trend_parameter_name = model.Trend_parameter_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

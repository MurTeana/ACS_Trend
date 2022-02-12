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
        public void AddNewTrend_parameter_type(Trend_parameter_type trend_Parameter_Type)
        {
            _context.Set<Trend_parameter_type>().Add(trend_Parameter_Type);
            _context.SaveChanges();
        }

        public int AddNewTrend_parameter_type(Trend_parameter_typeViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTrend_parameter_type(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Trend_parameter_type> GetAllTrend_parameter_types()
        {
            return _context.Set<Trend_parameter_type>().ToList();
        }

        public Trend_parameter_typeViewModel GetTrend_parameter_type(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTrend_parameter_type(int id, Trend_parameter_typeViewModel model)
        {
            throw new System.NotImplementedException();
        }

        List<Trend_parameter_typeViewModel> ITrend_parameter_typeRepository.GetAllTrend_parameter_types()
        {
            throw new System.NotImplementedException();
        }
    }
}

using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Trend_parameterRepository : GenericRepository<Trend_parameter>, ITrend_parameterRepository
    {
        public Trend_parameterRepository(ApplicationContext context) : base(context)
        {
        }
        public void AddNewTrend_parameter(Trend_parameter trend_Parameter)
        {
            _context.Set<Trend_parameter>().Add(trend_Parameter);
            _context.SaveChanges();
        }

        public int AddNewTrend_parameter(Trend_parameterViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTrend_parameter(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Trend_parameter> GetAllTrend_parameters()
        {
            return _context.Set<Trend_parameter>().ToList();
        }

        public Trend_parameterViewModel GetTrend_parameter(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTrend_parameter(int id, Trend_parameterViewModel model)
        {
            throw new System.NotImplementedException();
        }

        List<Trend_parameterViewModel> ITrend_parameterRepository.GetAllTrend_parameters()
        {
            throw new System.NotImplementedException();
        }
    }
}

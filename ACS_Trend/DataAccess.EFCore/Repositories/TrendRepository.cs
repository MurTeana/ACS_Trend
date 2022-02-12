using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class TrendRepository : GenericRepository<Trend>, ITrendRepository
    {
        public TrendRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNewListTrends(TrendViewModel Trend)
        {
            throw new System.NotImplementedException();
        }

        public int AddNewTrend(TrendViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTrend(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TrendViewModel> GetAllTrends()
        {
            throw new System.NotImplementedException();
        }

        public TrendViewModel GetTrend(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTrend(int id, TrendViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}

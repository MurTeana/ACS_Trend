using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendRepository : IGenericRepository<Trend>
    {
        int AddNewTrend(TrendViewModel model);
        List<TrendViewModel> GetAllTrends();
        TrendViewModel GetTrend(int id);
        bool UpdateTrend(int id, TrendViewModel model);
        bool DeleteTrend(int id);
    }
}

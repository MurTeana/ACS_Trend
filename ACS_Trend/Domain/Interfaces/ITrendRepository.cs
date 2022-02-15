using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendRepository : IGenericRepository<Trend>
    {
        int AddNewTrend(Trend model);
        List<Trend> GetAllTrends();
        Trend GetTrend(int id);
        bool UpdateTrend(int id, Trend model);
        bool DeleteTrend(int id);
    }
}

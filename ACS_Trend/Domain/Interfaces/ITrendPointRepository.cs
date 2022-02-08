using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendPointRepository : IGenericRepository<TrendPoint>
    {
        void AddNewTrendPoint(TrendPoint trendPoint);
        List<TrendPoint> GetAllTrendPoints();
    }
}

using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendPointRepository : IGenericRepository<TrendPointViewModel>
    {
        int AddNewTrendPoint(TrendPointViewModel model);
        void AddNewListTrendPoints(TrendPointViewModel trendPoint);
        List<TrendPointViewModel> GetAllTrendPoints();
        TrendPointViewModel GetTrendPoint(int id);
        bool UpdateTrendPoint(int id, TrendPointViewModel model);
        bool DeleteTrendPoint(int id);
    }
}

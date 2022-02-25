using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendPointRepository : IGenericRepository<TrendPointViewModel>
    {
        int AddNewTrendPoint(TrendPointViewModel model);
        List<TrendPointViewModel> AddNewListTrendPoints(List<TrendPointViewModel> trendPoints);
        List<TrendPointViewModel> GetAllTrendPoints();
        TrendPointViewModel GetTrendPoint(int id);
        List<TrendPointViewModel> GetListTrendPoints(int stid, int trpid);
        bool UpdateTrendPoint(int id, TrendPointViewModel model);
        bool DeleteTrendPoint(int id);
    }
}

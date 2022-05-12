using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameter_nameRepository : IGenericRepository<Trend_parameter_name>
    {
        int AddNewTrend_parameter_name(Trend_parameter_name model);
        List<Trend_parameter_name> GetAllTrend_parameter_names();
        Trend_parameter_name GetTrend_parameter_name(int id);
        bool UpdateTrend_parameter_name(int id, Trend_parameter_name model);
        bool DeleteTrend_parameter_name(int id);
    }
}

using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameter_typeRepository : IGenericRepository<Trend_parameter_type>
    {
        int AddNewTrend_parameter_type(Trend_parameter_type model);
        List<Trend_parameter_type> GetAllTrend_parameter_types();
        Trend_parameter_type GetTrend_parameter_type(int id);
        bool UpdateTrend_parameter_type(int id, Trend_parameter_type model);
        bool DeleteTrend_parameter_type(int id);
    }
}

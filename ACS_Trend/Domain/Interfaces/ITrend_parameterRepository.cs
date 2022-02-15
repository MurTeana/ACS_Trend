using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameterRepository : IGenericRepository<Trend_parameter>
    {
        int AddNewTrend_parameter(Trend_parameter model);
        List<Trend_parameter> GetAllTrend_parameters();
        Trend_parameter GetTrend_parameter(int id);
        bool UpdateTrend_parameter(int id, Trend_parameter model);
        bool DeleteTrend_parameter(int id);
    }
}

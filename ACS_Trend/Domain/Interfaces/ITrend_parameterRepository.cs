using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameterRepository : IGenericRepository<Trend_parameter>
    {
        void AddNewTrend_parameter(Trend_parameter trend_Parameter);
        List<Trend_parameter> GetAllTrend_parameters();
    }
}

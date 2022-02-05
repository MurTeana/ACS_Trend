using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameterRepository
    {
        IEnumerable<Trend_parameter> GetAllTrend_parameters();
    }
}

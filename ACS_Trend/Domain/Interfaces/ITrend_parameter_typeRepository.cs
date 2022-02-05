using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameter_typeRepository
    {
        IEnumerable<Trend_parameter_type> GetAllTrend_parameter_types();
    }
}

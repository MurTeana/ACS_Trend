using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameter_typeRepository : IGenericRepository<Trend_parameter_type>
    {
        void AddNewTrend_parameter_type(Trend_parameter_type trend_Parameter_Type);
        List<Trend_parameter_type> GetAllTrend_parameter_types();
    }
}

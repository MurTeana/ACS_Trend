using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrend_parameter_typeRepository : IGenericRepository<Trend_parameter_type>
    {
        int AddNewTrend_parameter_type(Trend_parameter_typeViewModel model);
        List<Trend_parameter_typeViewModel> GetAllTrend_parameter_types();
        Trend_parameter_typeViewModel GetTrend_parameter_type(int id);
        bool UpdateTrend_parameter_type(int id, Trend_parameter_typeViewModel model);
        bool DeleteTrend_parameter_type(int id);
    }
}

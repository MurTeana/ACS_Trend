using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStation_typeRepository : IGenericRepository<Station_typeViewModel>
    {
        int AddNewStation_type(Station_typeViewModel station_Type);
        List<Station_type> GetAllStation_types();
    }
}

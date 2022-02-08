using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStation_typeRepository : IGenericRepository<Station_type>
    {
        void AddNewStation_type(Station_type station_Type);
        List<Station_type> GetAllStation_types();
    }
}

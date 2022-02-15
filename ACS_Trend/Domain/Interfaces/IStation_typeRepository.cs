using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStation_typeRepository : IGenericRepository<Station_type>
    {
        int AddNewStation_type(Station_type station_Type);
        List<Station_type> GetAllStation_types();
        Station_type GetStation_type(int id);
        bool UpdateStation_type(int id, Station_type model);
        bool DeleteStation_type(int id);
    }
}

using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStation_typeRepository : IGenericRepository<Station_typeViewModel>
    {
        int AddNewStation_type(Station_typeViewModel station_Type);
        List<Station_typeViewModel> GetAllStation_types();
        Station_typeViewModel GetStation_type(int id);
        bool UpdateStation_type(int id, Station_typeViewModel model);
        bool DeleteStation_type(int id);
    }
}

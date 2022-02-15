using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        int AddNewStation(Station model);
        List<Station> GetAllStations();
        Station GetStation(int id);
        bool UpdateStation(int id, Station model);
        bool DeleteStation(int id);
    }
}

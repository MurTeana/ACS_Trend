using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        void AddNewStation(Station station);
        List<Station> GetAllStations();
    }
}

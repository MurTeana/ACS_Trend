using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStationRepository : IGenericRepository<StationViewModel>
    {
        int AddNewStation(StationViewModel station);
        List<StationViewModel> GetAllStations();
    }
}

using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStationRepository : IGenericRepository<StationViewModel>
    {
        int AddNewStation(StationViewModel model);
        List<StationViewModel> GetAllStations();
        StationViewModel GetStation(int id);
        bool UpdateStation(int id, StationViewModel model);
        bool DeleteStation(int id);
    }
}

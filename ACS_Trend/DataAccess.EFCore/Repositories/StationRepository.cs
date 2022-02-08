using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNewStation(Station station)
        {
            _context.Set<Station>().Add(station);
            _context.SaveChanges();
        }
        public List<Station> GetAllStations()
        {
            return _context.Set<Station>().ToList();
        }
    }
}

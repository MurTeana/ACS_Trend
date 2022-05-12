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

        public int AddNewStation(Station model)
        {
            Station st = new Station()
            {
                Station_name = model.Station_name,
                ElectricalPower = model.ElectricalPower,
                HeatPower = model.HeatPower
            };

            if (model.Station_type != null)
            {
                var id = model.Station_type.ID_Station_type;
                st.ST_ID_Station_type = id;
            }

            _context.Set<Station>().Add(st);
            _context.SaveChanges();

            return st.ID_Station;
        }

        public List<Station> GetAllStations()
        {
            var result = _context.Stations
                .Select(x => new Station()
                {
                    ID_Station = x.ID_Station,
                    Station_name = x.Station_name,
                    ST_ID_Station_type = x.ST_ID_Station_type,
                    ElectricalPower = x.ElectricalPower,
                    HeatPower = x.HeatPower,
                    Station_type = x.Station_type
                }).ToList();

            return result;
        }

        public bool DeleteStation(int id)
        {
            var Station = _context.Stations.FirstOrDefault(x => x.ID_Station == id);

            if (Station != null)
            {
                _context.Stations.Remove(Station);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Station GetStation(int id)
        {
            var result = _context.Stations
                .Where(x => x.ID_Station == id)
                .Select(x => new Station()
                {
                    ID_Station = x.ID_Station,
                    Station_name = x.Station_name,
                    ElectricalPower = x.ElectricalPower,
                    HeatPower = x.HeatPower,
                    ST_ID_Station_type = x.ST_ID_Station_type,
                    Station_type = x.Station_type
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateStation(int id, Station model)
        {
            var Station = _context.Stations.FirstOrDefault(x => x.ID_Station == id);

            if (Station != null)
            {
                Station.Station_name = model.Station_name;
                Station.ST_ID_Station_type = model.ST_ID_Station_type;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

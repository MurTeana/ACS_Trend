using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class StationRepository : GenericRepository<StationViewModel>, IStationRepository
    {
        public StationRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewStation(StationViewModel model)
        {
            Station st = new Station()
            {
                Station_name = model.Station_name,
                ElectricalPower = model.ElectricalPower,
                HeatPower = model.HeatPower
            };

            if (model.Station_Type != null)
            {
                var id = model.Station_Type.ID_Station_type;
                st.ST_ID_Station_type = id;
            }

            _context.Set<Station>().Add(st);
            _context.SaveChanges();

            return st.ID_Station;
        }

        public List<StationViewModel> GetAllStations()
        {
            var result = _context.Stations
                .Select(x => new StationViewModel()
                {
                    ID_Station = x.ID_Station,
                    Station_name = x.Station_name,
                    ST_ID_Station_type = x.ST_ID_Station_type,
                    ElectricalPower = x.ElectricalPower,
                    HeatPower = x.HeatPower,

                    Station_Type = new Station_typeViewModel()
                    {
                        ID_Station_type = x.Station_type.ID_Station_type,
                        Station_type_name = x.Station_type.Station_type_name
                    }
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

        public StationViewModel GetStation(int id)
        {
            var result = _context.Stations
                .Where(x => x.ID_Station == id)
                .Select(x => new StationViewModel()
                {
                    ID_Station = x.ID_Station,
                    Station_name = x.Station_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateStation(int id, StationViewModel model)
        {
            var Station = _context.Stations.FirstOrDefault(x => x.ID_Station == id);

            if (Station != null)
            {
                Station.Station_name = model.Station_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

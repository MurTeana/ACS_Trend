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

        public bool DeleteStation(int id)
        {
            throw new System.NotImplementedException();
        }

        public StationViewModel GetStation(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateStation(int id, StationViewModel model)
        {
            throw new System.NotImplementedException();
        }

        int AddNewStation(StationViewModel model)
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

        int IStationRepository.AddNewStation(StationViewModel model)
        {
            throw new System.NotImplementedException();
        }

        List<StationViewModel> GetAllStations()
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
                        StationType = x.Station_type.StationType
                    }
                }).ToList();

            return result;
        }

        List<StationViewModel> IStationRepository.GetAllStations()
        {
            throw new System.NotImplementedException();
        }
    }
}

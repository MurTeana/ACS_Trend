using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class TrendRepository : GenericRepository<Trend>, ITrendRepository
    {
        public TrendRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNewListTrends(TrendViewModel Trend)
        {
            throw new System.NotImplementedException();
        }

        public int AddNewTrend(TrendViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTrend(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<TrendViewModel> GetAllTrends()
        {
            var result = _context.Trends
            .Select(x => new TrendViewModel()
            {
                ID_Trend = x.ID_Trend,
                T_ID_Station = x.T_ID_Station,
                T_ID_Trend_parameter = x.T_ID_Trend_parameter,
                T_ID_Unit = x.T_ID_Unit,

                Station = new StationViewModel()
                {
                    ID_Station = x.Station.ID_Station,
                    Station_name = x.Station.Station_name
                },

                Trend_parameter = new Trend_parameterViewModel()
                {
                    ID_Trend_parameter = x.Trend_parameter.ID_Trend_parameter,
                    Trend_parameter_name = x.Trend_parameter.Trend_parameter_name
                },

                Unit = new UnitViewModel()
                {
                    ID_Unit = x.Unit.ID_Unit
                }
            }).ToList();

            return result;
        }

        public TrendViewModel GetTrend(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTrend(int id, TrendViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}

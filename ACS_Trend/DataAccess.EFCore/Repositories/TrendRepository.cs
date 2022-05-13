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

        public int AddNewTrend(Trend model)
        {
            _context.Trends.Add(model);
            _context.SaveChanges();

            return model.ID_Trend;
        }

        public bool DeleteTrend(int id)
        {
            var trend = _context.Trends.FirstOrDefault(x => x.ID_Trend == id);

            if (trend != null)
            {
                _context.Trends.Remove(trend);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Trend> GetAllTrends()
        {
            var result = _context.Trends
                .Select(x => new Trend()
                {
                    ID_Trend = x.ID_Trend,
                    T_ID_Station = x.T_ID_Station,
                    T_ID_Control_object = x.T_ID_Control_object,
                    T_ID_Regulator = x.T_ID_Regulator,
                    T_ID_Signal_type = x.T_ID_Signal_type,
                    T_ID_Trend_parameter_name = x.T_ID_Trend_parameter_name,
                    T_ID_Unit = x.T_ID_Unit,
                    Station = x.Station,
                    Control_object = x.Control_object,
                    Regulator = x.Regulator,
                    Signal_type = x.Signal_type,
                    Trend_parameter_name = x.Trend_parameter_name,
                    Unit = x.Unit
                }).ToList();

            return result;
        }

        public Trend GetTrend(int id)
        {
            var result = _context.Trends
                .Where(x => x.ID_Trend == id)
                .Select(x => new Trend()
                {
                    ID_Trend = x.ID_Trend,
                    T_ID_Station = x.T_ID_Station,
                    T_ID_Control_object = x.T_ID_Control_object,
                    T_ID_Regulator = x.T_ID_Regulator,
                    T_ID_Signal_type = x.T_ID_Signal_type,
                    T_ID_Trend_parameter_name = x.T_ID_Trend_parameter_name,
                    T_ID_Unit = x.T_ID_Unit,
                    Station = x.Station,
                    Control_object = x.Control_object,
                    Regulator = x.Regulator,
                    Signal_type = x.Signal_type,
                    Trend_parameter_name = x.Trend_parameter_name,
                    Unit = x.Unit
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTrend(int id, Trend model)
        {
            var trend = _context.Trends.FirstOrDefault(x => x.ID_Trend == id);

            if (trend != null)
            {
                trend.ID_Trend = model.ID_Trend;
                trend.T_ID_Station = model.T_ID_Station;
                trend.T_ID_Control_object = model.T_ID_Control_object;
                trend.T_ID_Regulator = model.T_ID_Regulator;
                trend.T_ID_Signal_type = model.T_ID_Signal_type;
                trend.T_ID_Trend_parameter_name = model.T_ID_Trend_parameter_name;
                trend.T_ID_Unit = model.T_ID_Unit;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

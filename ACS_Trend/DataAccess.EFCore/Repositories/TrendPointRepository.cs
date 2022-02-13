using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class TrendPointRepository : GenericRepository<TrendPointViewModel>, ITrendPointRepository
    {
        public TrendPointRepository(ApplicationContext context) : base(context)
        {
        }
        public int AddNewTrendPoint(TrendPointViewModel model)
        {
            TrendPoint tp = new TrendPoint()
            {
                Date_time = model.Date_time,
                Parameter = model.Parameter
            };

            if (model.Trend != null)
            {
                var id = model.Trend.ID_Trend;
                tp.TP_ID_Trend = id;
            }

            _context.Set<TrendPoint>().Add(tp);
            _context.SaveChanges();

            return tp.ID_TrendPoint;
        }

        public List<TrendPointViewModel> AddNewListTrendPoints(List<TrendPointViewModel> trendPoints)
        {
            List <TrendPoint> points = new List<TrendPoint>();

            foreach (var item in trendPoints)
            {
                TrendPoint tp = new TrendPoint();

                tp.Date_time = item.Date_time;
                tp.Parameter = item.Parameter;
                tp.TP_ID_Trend = item.TP_ID_Trend;

                points.Add(tp);
            }

            _context.TrendPoints.AddRange(points);
            _context.SaveChanges();
            return trendPoints;
        }

        public List<TrendPointViewModel> GetAllTrendPoints()
        {
            var result = _context.TrendPoints
                .Select(x => new TrendPointViewModel()
                {
                    ID_TrendPoint = x.ID_TrendPoint,
                    Date_time = x.Date_time,
                    Parameter = x.Parameter,
                    TP_ID_Trend = x.TP_ID_Trend,

                    Trend = new TrendViewModel()
                    {
                        ID_Trend = x.Trend.ID_Trend,
                        T_ID_Station = x.Trend.T_ID_Station,
                        T_ID_Trend_parameter = x.Trend.T_ID_Trend_parameter,
                        T_ID_Unit = x.Trend.T_ID_Unit,

                        Station = new StationViewModel()
                        {
                            Station_name = x.Trend.Station.Station_name
                        },

                        Trend_parameter = new Trend_parameterViewModel()
                        {
                            Trend_parameter_name = x.Trend.Trend_parameter.Trend_parameter_name
                        },

                        Unit = new UnitViewModel()
                        {
                            Unit_name = x.Trend.Unit.Unit_name
                        }
                    }
                }).ToList();

            return result;
        }

        public TrendPointViewModel GetTrendPoint(int id)
        {
            var result = _context.TrendPoints
                .Where(x => x.ID_TrendPoint == id)
                .Select(x => new TrendPointViewModel()
                {
                    ID_TrendPoint = x.ID_TrendPoint,
                    Date_time = x.Date_time,
                    Parameter = x.Parameter
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTrendPoint(int id, TrendPointViewModel model)
        {
            var TrendPoint = _context.TrendPoints.FirstOrDefault(x => x.ID_TrendPoint == id);

            if (TrendPoint != null)
            {
                TrendPoint.Date_time = model.Date_time;
                TrendPoint.Parameter = model.Parameter;
            }

            _context.SaveChanges();
            return true;
        }

        public bool DeleteTrendPoint(int id)
        {
            var tp = _context.TrendPoints.FirstOrDefault(x => x.ID_TrendPoint == id);

            if (tp != null)
            {
                _context.TrendPoints.Remove(tp);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

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
            Trend_parameter tparam = new Trend_parameter()
            {
                Trend_parameter_name = model.Trend.Trend_parameter.Trend_parameter_name,
                TP_ID_Control_object = model.Trend.Trend_parameter.TP_ID_Control_object,
                TP_ID_Signal_type = model.Trend.Trend_parameter.TP_ID_Signal_type,
                TP_ID_Regulator = model.Trend.Trend_parameter.TP_ID_Regulator,
                TP_ID_Trend_parameter_type = model.Trend.Trend_parameter.TP_ID_Trend_parameter_type
            };

            _context.Set<Trend_parameter>().Add(tparam);
            _context.SaveChanges();

            TrendPoint tp = new TrendPoint()
            {
                Date_time = model.Date_time,
                Parameter = model.Parameter,
            };

            tp.Trend = new Trend()
            {
                T_ID_Station = model.Trend.T_ID_Station,                
                T_ID_Unit = model.Trend.T_ID_Unit,
                T_ID_Trend_parameter = tparam.ID_Trend_parameter
            };

            if (model.Trend != null)
            {
                tp.TP_ID_Trend = tp.Trend.ID_Trend;
            }

            _context.Set<TrendPoint>().Add(tp);
            _context.SaveChanges();

            return tp.ID_TrendPoint;
        }

        public List<TrendPointViewModel> AddNewListTrendPoints(List<TrendPointViewModel> trendPoints)
        {
            Trend_parameter tparam = new Trend_parameter()
            {
                Trend_parameter_name = trendPoints[0].Trend_parameter.Trend_parameter_name,
                TP_ID_Control_object = trendPoints[0].Trend_parameter.TP_ID_Control_object,
                TP_ID_Signal_type = trendPoints[0].Trend_parameter.TP_ID_Signal_type,
                TP_ID_Regulator = trendPoints[0].Trend_parameter.TP_ID_Regulator,
                TP_ID_Trend_parameter_type = trendPoints[0].Trend_parameter.TP_ID_Trend_parameter_type
            };

            _context.Set<Trend_parameter>().Add(tparam);
            _context.SaveChanges();

            List <TrendPoint> points = new List<TrendPoint>();

            foreach (var item in trendPoints)
            {
                TrendPoint tp = new TrendPoint();

                tp.Date_time = item.Date_time;
                tp.Parameter = item.Parameter;

                tp.Trend = new Trend()
                {
                    T_ID_Station = trendPoints[0].Trend.T_ID_Station,
                    T_ID_Unit = trendPoints[0].Trend.T_ID_Unit,
                    T_ID_Trend_parameter = tparam.ID_Trend_parameter
                };

                if (trendPoints[0].Trend != null)
                {
                    tp.TP_ID_Trend = tp.Trend.ID_Trend;
                }

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
                    TP_Station = x.Trend.Station.Station_name,
                    TP_Trend_parameter = x.Trend.Trend_parameter.Trend_parameter_name,
                    TP_Unit = x.Trend.Unit.Unit_name,

                    Trend = x.Trend

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

        public List<TrendPointViewModel> GetListTrendPoints(int stid, int trpid)
        {
            var result = _context.TrendPoints
                .Where(x => x.Trend.Station.ID_Station == stid && x.Trend.Trend_parameter.ID_Trend_parameter == trpid)
                .Select(x => new TrendPointViewModel()
                {
                    ID_TrendPoint = x.ID_TrendPoint,
                    Date_time = x.Date_time,
                    Parameter = x.Parameter,
                    TP_Station = x.Trend.Station.Station_name,
                    TP_Trend_parameter = x.Trend.Trend_parameter.Trend_parameter_name,
                    TP_Unit = x.Trend.Unit.Unit_name
                }).ToList();

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

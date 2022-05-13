using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Transient_characteristicPointRepository : GenericRepository<Transient_characteristicPointViewModel>, ITransient_characteristicPointRepository
    {
        public Transient_characteristicPointRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewListTransient_characteristicPoints(Transient_characteristicPointViewModel trcharmodel)
        {
            Trend trendIn = new Trend()
            {
                T_ID_Station = trcharmodel.TrendIN.T_ID_Station,
                T_ID_Unit = trcharmodel.TrendIN.T_ID_Unit,
                T_ID_Trend_parameter_name = trcharmodel.TrendIN.T_ID_Trend_parameter_name,
                T_ID_Control_object = trcharmodel.TrendIN.T_ID_Control_object,
                T_ID_Signal_type = trcharmodel.TrendIN.T_ID_Signal_type,
                T_ID_Regulator = trcharmodel.TrendIN.T_ID_Regulator,
            };

            List<TrendPoint> pointsIN = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsIN)
            {
                TrendPoint tpIN = new TrendPoint()
                {
                    Date_time = item[0],
                    Parameter = item[1]
                };

                pointsIN.Add(tpIN);
            }

            trendIn.TrendPoints = pointsIN;

            _context.Trends.Add(trendIn);
            _context.SaveChanges();

            
            Trend trendOut = new Trend()
            {
                T_ID_Station = trcharmodel.TrendIN.T_ID_Station,
                T_ID_Unit = trcharmodel.TrendOUT.T_ID_Unit,
                T_ID_Trend_parameter_name = trcharmodel.TrendOUT.T_ID_Trend_parameter_name,
                T_ID_Control_object = trcharmodel.TrendIN.T_ID_Control_object,
                T_ID_Signal_type = trcharmodel.TrendOUT.T_ID_Signal_type,
                T_ID_Regulator = trcharmodel.TrendIN.T_ID_Regulator,
            };

            List<TrendPoint> pointsOUT = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsOUT)
            {
                TrendPoint tpOUT = new TrendPoint()
                {
                    Date_time = item[0],
                    Parameter = item[1],
                    Trend = trendIn
                };

                pointsOUT.Add(tpOUT);
            }

            trendOut.TrendPoints = pointsOUT;

            _context.Trends.Add(trendOut);
            _context.SaveChanges();
                     
            foreach (var trcharpoints in trcharmodel.trCharListpoints)
            {
                Transient_characteristic trch = new Transient_characteristic();

                List<Transient_characteristicPoint> trPoints = new List<Transient_characteristicPoint>();

                foreach (var item in trcharpoints)
                {
                    Transient_characteristicPoint trPoint = new Transient_characteristicPoint() 
                    {
                        Date_time = item[0],
                        Parameter = item[1],
                        Transient_characteristic = trch
                    };

                    trPoints.Add(trPoint);
                }

                trch.Transient_characteristicPoints = trPoints;

                _context.Transient_characteristics.Add(trch);
                _context.SaveChanges();

                _context.Trend_Transient_characteristics.Add(new Trend_Transient_characteristic { Trend = trendIn, Transient_characteristic = trch });
                _context.Trend_Transient_characteristics.Add(new Trend_Transient_characteristic { Trend = trendOut, Transient_characteristic = trch });

                _context.SaveChanges();
            }

            return 0;
        }

        public List<List<Transient_characteristicPoint>> FindTransCharByTrendID(int trendID)
        {
            var listTransChars = _context.Transient_characteristics
                .Include(t => t.Trend_Transient_characteristics)
                .ThenInclude(tr => tr.Trend)
                .ToList();

            var trend = _context.Trends
                .Include(t => t.Trend_Transient_characteristics)
                .ThenInclude(tr => tr.Transient_characteristic)
                .ThenInclude(p => p.Transient_characteristicPoints)
                .Where(x => x.ID_Trend == trendID)
                .FirstOrDefault();

            var trchpoints = new List<List<Transient_characteristicPoint>>();

            foreach (var item in trend.Trend_Transient_characteristics)
            {
                var listpoints = item.Transient_characteristic.Transient_characteristicPoints.OrderBy(t => t.Date_time).ToList();
                trchpoints.Add(listpoints);
            }

            return trchpoints;
        }
    }
}

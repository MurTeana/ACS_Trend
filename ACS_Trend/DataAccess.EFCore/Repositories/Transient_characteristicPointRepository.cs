using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System;
using System.Collections.Generic;
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

            _context.Trends.Add(trendIn);
            _context.SaveChanges();

            List<TrendPoint> pointsIN = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsIN)
            {
                TrendPoint tpIN = new TrendPoint(item[0], item[1]);

                if (trcharmodel.TrendIN != null)
                {
                    tpIN.TP_ID_Trend = trendIn.ID_Trend;
                }

                pointsIN.Add(tpIN);
            }

            _context.TrendPoints.AddRange(pointsIN);
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

            _context.Trends.Add(trendOut);
            _context.SaveChanges();

            List<TrendPoint> pointsOUT = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsOUT)
            {
                TrendPoint tpOUT = new TrendPoint(item[0], item[1]);

                if (trcharmodel.TrendOUT != null)
                {
                    tpOUT.TP_ID_Trend = trendOut.ID_Trend;
                }

                pointsOUT.Add(tpOUT);
            }

            _context.TrendPoints.AddRange(pointsOUT);
            _context.SaveChanges();
          
            foreach (var trcharpoints in trcharmodel.trCharListpoints)
            {
                Transient_characteristic trch = new Transient_characteristic();

                _context.Transient_characteristics.Add(trch);
                _context.SaveChanges();

                List<Transient_characteristicPoint> trPoints = new List<Transient_characteristicPoint>();

                foreach (var item in trcharpoints)
                {
                    Transient_characteristicPoint trPoint = new Transient_characteristicPoint(item[0], item[1]);

                    if (trch != null)
                    {
                        trPoint.TPCHP_ID_Transient_characteristic = trch.ID_Transient_characteristic;
                    }

                    trPoints.Add(trPoint);
                }

                _context.Transient_characteristicPoints.AddRange(trPoints);
                _context.SaveChanges();


                Trend_Transient_characteristic trtchIN = new Trend_Transient_characteristic()
                {
                    TTCH_ID_Trend = trendIn.ID_Trend,
                    TTCH_ID_Transient_characteristic = trch.ID_Transient_characteristic
                };

                _context.Trend_Transient_characteristics.Add(trtchIN);
                _context.SaveChanges();

                Trend_Transient_characteristic trtchOUT = new Trend_Transient_characteristic()
                {
                    TTCH_ID_Trend = trendOut.ID_Trend,
                    TTCH_ID_Transient_characteristic = trch.ID_Transient_characteristic

                };

                _context.Trend_Transient_characteristics.Add(trtchOUT);
                _context.SaveChanges();
            }
        
            return 0;
        }


        public int AddNewTransient_characteristicPoint(Transient_characteristicPointViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransient_characteristicPoint(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transient_characteristicPointViewModel> Find(Expression<Func<Transient_characteristicPointViewModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Transient_characteristicPointViewModel> GetAllTransient_characteristicPoints()
        {
            throw new NotImplementedException();
        }

        public List<Transient_characteristicPointViewModel> GetListTransient_characteristicPoints(int stid, int trpid)
        {
            throw new NotImplementedException();
        }

        public Transient_characteristicPointViewModel GetTransient_characteristicPoint(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransient_characteristicPoint(int id, Transient_characteristicPointViewModel model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transient_characteristicPointViewModel> IGenericRepository<Transient_characteristicPointViewModel>.GetAll()
        {
            throw new NotImplementedException();
        }

        Transient_characteristicPointViewModel IGenericRepository<Transient_characteristicPointViewModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

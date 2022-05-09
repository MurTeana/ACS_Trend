using ACS_Transient_characteristic.Domain.Interfaces;
using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
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

        public Transient_characteristicPointViewModel AddNewListTransient_characteristicPoints(Transient_characteristicPointViewModel trcharmodel)
        {
            Trend_parameter tparamIN = new Trend_parameter()
            {
                Trend_parameter_name = trcharmodel.TrendIN.Trend_parameter.Trend_parameter_name,
                TP_ID_Control_object = trcharmodel.TrendIN.Trend_parameter.TP_ID_Control_object,
                TP_ID_Signal_type = trcharmodel.TrendIN.Trend_parameter.TP_ID_Signal_type,
                TP_ID_Regulator = trcharmodel.TrendIN.Trend_parameter.TP_ID_Regulator,
                TP_ID_Trend_parameter_type = trcharmodel.TrendIN.Trend_parameter.TP_ID_Trend_parameter_type
            };

            _context.Set<Trend_parameter>().Add(tparamIN);
            _context.SaveChanges();

            Trend_parameter tparamOUT = new Trend_parameter()
            {
                Trend_parameter_name = trcharmodel.TrendOUT.Trend_parameter.Trend_parameter_name,
                TP_ID_Control_object = trcharmodel.TrendOUT.Trend_parameter.TP_ID_Control_object,
                TP_ID_Signal_type = trcharmodel.TrendOUT.Trend_parameter.TP_ID_Signal_type,
                TP_ID_Regulator = trcharmodel.TrendOUT.Trend_parameter.TP_ID_Regulator,
                TP_ID_Trend_parameter_type = trcharmodel.TrendOUT.Trend_parameter.TP_ID_Trend_parameter_type
            };

            _context.Set<Trend_parameter>().Add(tparamOUT);
            _context.SaveChanges();

            List<TrendPoint> pointsIN = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsIN)
            {
                TrendPoint tpIN = new TrendPoint();

                tpIN.Date_time = item.Date_time;
                tpIN.Parameter = item.Parameter;

                tpIN.Trend = new Trend()
                {
                    T_ID_Station = trcharmodel.TrendIN.T_ID_Station,
                    T_ID_Unit = trcharmodel.TrendIN.T_ID_Unit,
                    T_ID_Trend_parameter = tparamIN.ID_Trend_parameter
                };

                if (trcharmodel.TrendIN != null)
                {
                    tpIN.TP_ID_Trend = tpIN.Trend.ID_Trend;
                }

                pointsIN.Add(tpIN);
            }

            _context.TrendPoints.AddRange(pointsIN);
            _context.SaveChanges();

            List<TrendPoint> pointsOUT = new List<TrendPoint>();

            foreach (var item in trcharmodel.pointsOUT)
            {
                TrendPoint tpOUT = new TrendPoint();

                tpOUT.Date_time = item.Date_time;
                tpOUT.Parameter = item.Parameter;

                tpOUT.Trend = new Trend()
                {
                    T_ID_Station = trcharmodel.TrendIN.T_ID_Station,
                    T_ID_Unit = trcharmodel.TrendOUT.T_ID_Unit,
                    T_ID_Trend_parameter = tparamIN.ID_Trend_parameter
                };

                if (trcharmodel.TrendIN != null)
                {
                    tpOUT.TP_ID_Trend = tpOUT.Trend.ID_Trend;
                }

                pointsOUT.Add(tpOUT);
            }

            _context.TrendPoints.AddRange(pointsOUT);
            _context.SaveChanges();

            List<Transient_characteristicPoint> trPoints = new List<Transient_characteristicPoint>();

            foreach (var item in trcharmodel.trCharpoints)
            {
                Transient_characteristicPoint trPoint = new Transient_characteristicPoint();

                trPoint.Date_time = item.Date_time;
                trPoint.Parameter = item.Parameter;

                trPoint.Transient_characteristic = new Transient_characteristic();

                if (trPoint.Transient_characteristic != null)
                {
                    trPoint.TPCHP_ID_Transient_characteristic = trPoint.Transient_characteristic.ID_Transient_characteristic;
                }

                trPoints.Add(trPoint);
            }

            _context.Transient_characteristicPoints.AddRange(trPoints);
            _context.SaveChanges();

            Trend_Transient_characteristic trtchIN = new Trend_Transient_characteristic()
            {
                TTCH_ID_Trend = pointsIN[0].TP_ID_Trend,
                TTCH_ID_Transient_characteristic = trPoints[0].TPCHP_ID_Transient_characteristic
            };

            _context.Trend_Transient_characteristics.Add(trtchIN);
            _context.SaveChanges();

            Trend_Transient_characteristic trtchOUT = new Trend_Transient_characteristic()
            {
                TTCH_ID_Trend = pointsOUT[0].TP_ID_Trend,
                TTCH_ID_Transient_characteristic = trPoints[0].TPCHP_ID_Transient_characteristic

            };

            _context.Trend_Transient_characteristics.Add(trtchOUT);
            _context.SaveChanges();


            throw new NotImplementedException();
        }

        public List<Transient_characteristicPointViewModel> AddNewListTransient_characteristicPoints(List<Transient_characteristicPointViewModel> Transient_characteristicPoints)
        {
            throw new NotImplementedException();
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

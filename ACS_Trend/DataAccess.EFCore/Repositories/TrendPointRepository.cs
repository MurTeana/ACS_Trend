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

        public void AddNewListTrendPoints(TrendPointViewModel trendPoint)
        {
            throw new System.NotImplementedException();
        }

        public List<TrendPointViewModel> GetAllTrendPoints()
        {
            throw new System.NotImplementedException();
        }

        public TrendPointViewModel GetTrendPoint(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTrendPoint(int id, TrendPointViewModel model)
        {
            throw new System.NotImplementedException();
        }
        public bool DeleteTrendPoint(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

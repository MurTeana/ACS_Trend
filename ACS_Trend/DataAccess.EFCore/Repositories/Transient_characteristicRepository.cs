using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Transient_characteristicRepository : GenericRepository<Transient_characteristicViewModel>, ITransient_characteristicRepository
    {
        public Transient_characteristicRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewTransient_characteristic(Transient_characteristicViewModel model)
        {
            Transient_characteristic tch = new Transient_characteristic()
            {
                Date_time = model.Date_time,
                Parameter = model.Parameter
            };

            if (model.Trend != null)
            {
                var id = model.Trend.ID_Trend;
                tch.TCH_ID_Trend = id;
            }

            _context.Transient_characteristics.Add(tch);
            _context.SaveChanges();

            return tch.ID_Transient_characteristic;
        }

        public bool DeleteTransient_characteristic(int id)
        {
            var Transient_characteristic = _context.Transient_characteristics.FirstOrDefault(x => x.ID_Transient_characteristic == id);

            if (Transient_characteristic != null)
            {
                _context.Transient_characteristics.Remove(Transient_characteristic);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Transient_characteristicViewModel> GetAllTransient_characteristics()
        {
            var result = _context.Transient_characteristics
                .Select(x => new Transient_characteristicViewModel()
                {
                    ID_Transient_characteristic = x.ID_Transient_characteristic,
                    Date_time = x.Date_time,
                    Parameter = x.Parameter
                }).ToList();

            return result;
        }

        public Transient_characteristicViewModel GetTransient_characteristic(int id)
        {
            var result = _context.Transient_characteristics
                .Where(x => x.ID_Transient_characteristic == id)
                .Select(x => new Transient_characteristicViewModel()
                {
                    ID_Transient_characteristic = x.ID_Transient_characteristic,
                    Date_time = x.Date_time,
                    Parameter = x.Parameter
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateTransient_characteristic(int id, Transient_characteristicViewModel model)
        {
            var Transient_characteristic = _context.Transient_characteristics.FirstOrDefault(x => x.ID_Transient_characteristic == id);

            if (Transient_characteristic != null)
            {
                Transient_characteristic.Date_time = model.Date_time;
                Transient_characteristic.Parameter = model.Parameter;
            }

            _context.SaveChanges();
            return true;
        }

        List<TrendPointViewModel> ITransient_characteristicRepository.AddNewListTransient_characteristics(Transient_characteristicViewModel Transient_characteristic)
        {
            throw new System.NotImplementedException();
        }
    }
}

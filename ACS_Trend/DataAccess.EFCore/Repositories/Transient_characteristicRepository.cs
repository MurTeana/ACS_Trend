using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Transient_characteristicRepository : GenericRepository<Transient_characteristic>, ITransient_characteristicRepository
    {
        public Transient_characteristicRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddNewListTransient_characteristics(Transient_characteristicViewModel Transient_characteristic)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewTransient_characteristic(Transient_characteristic transient_Characteristic)
        {
            _context.Set<Transient_characteristic>().Add(transient_Characteristic);
            _context.SaveChanges();
        }

        public int AddNewTransient_characteristic(Transient_characteristicViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTransient_characteristic(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Transient_characteristic> GetAllTransient_characteristics()
        {
            return _context.Set<Transient_characteristic>().ToList();
        }

        public Transient_characteristicViewModel GetTransient_characteristic(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTransient_characteristic(int id, Transient_characteristicViewModel model)
        {
            throw new System.NotImplementedException();
        }

        List<Transient_characteristicViewModel> ITransient_characteristicRepository.GetAllTransient_characteristics()
        {
            throw new System.NotImplementedException();
        }
    }
}

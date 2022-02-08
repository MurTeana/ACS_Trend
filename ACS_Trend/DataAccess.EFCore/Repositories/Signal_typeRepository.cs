using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Signal_typeRepository : GenericRepository<Signal_type>, ISignal_typeRepository
    {
        public Signal_typeRepository(ApplicationContext context) : base(context)
        {
        }
        public void AddNewSignal_type(Signal_type signal_Type)
        {
            _context.Set<Signal_type>().Add(signal_Type);
            _context.SaveChanges();
        }
        public List<Signal_type> GetAllSignal_types()
        {
            return _context.Set<Signal_type>().ToList();
        }
    }
}

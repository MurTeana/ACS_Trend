using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Signal_typeRepository : GenericRepository<Signal_type>, ISignal_typeRepository
    {
        public Signal_typeRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewSignal_type(Signal_type model)
        {
            _context.Signal_types.Add(model);
            _context.SaveChanges();

            return model.ID_Signal_type;
        }

        public bool DeleteSignal_type(int id)
        {
            var Signal_type = _context.Signal_types.FirstOrDefault(x => x.ID_Signal_type == id);

            if (Signal_type != null)
            {
                _context.Signal_types.Remove(Signal_type);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Signal_type> GetAllSignal_types()
        {
            var result = _context.Signal_types
                .Select(x => new Signal_type()
                {
                    ID_Signal_type = x.ID_Signal_type,
                    Signal_type_name = x.Signal_type_name,
                }).ToList();

            return result;
        }

        public Signal_type GetSignal_type(int id)
        {
            var result = _context.Signal_types
                .Where(x => x.ID_Signal_type == id)
                .Select(x => new Signal_type()
                {
                    ID_Signal_type = x.ID_Signal_type,
                    Signal_type_name = x.Signal_type_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateSignal_type(int id, Signal_type model)
        {
            var Signal_type = _context.Signal_types.FirstOrDefault(x => x.ID_Signal_type == id);

            if (Signal_type != null)
            {
                Signal_type.Signal_type_name = model.Signal_type_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

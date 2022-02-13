using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class RegulatorRepository : GenericRepository<Regulator>, IRegulatorRepository
    {
        public RegulatorRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewRegulator(RegulatorViewModel model)
        {
            Regulator Regulator = new Regulator()
            {
                Regulator_name = model.Regulator_name
            };

            _context.Regulators.Add(Regulator);
            _context.SaveChanges();

            return Regulator.ID_Regulator;
        }

        public bool DeleteRegulator(int id)
        {
            var Regulator = _context.Regulators.FirstOrDefault(x => x.ID_Regulator == id);

            if (Regulator != null)
            {
                _context.Regulators.Remove(Regulator);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<RegulatorViewModel> GetAllRegulators()
        {
            var result = _context.Regulators
                .Select(x => new RegulatorViewModel()
                {
                    ID_Regulator = x.ID_Regulator,
                    Regulator_name = x.Regulator_name,
                }).ToList();

            return result;
        }

        public RegulatorViewModel GetRegulator(int id)
        {
            var result = _context.Regulators
                .Where(x => x.ID_Regulator == id)
                .Select(x => new RegulatorViewModel()
                {
                    ID_Regulator = x.ID_Regulator,
                    Regulator_name = x.Regulator_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateRegulator(int id, RegulatorViewModel model)
        {
            var Regulator = _context.Regulators.FirstOrDefault(x => x.ID_Regulator == id);

            if (Regulator != null)
            {
                Regulator.Regulator_name = model.Regulator_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

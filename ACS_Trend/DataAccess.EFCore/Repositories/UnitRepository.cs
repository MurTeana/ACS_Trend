using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewUnit(Unit model)
        {
            _context.Units.Add(model);
            _context.SaveChanges();

            return model.ID_Unit;
        }

        public bool DeleteUnit(int id)
        {
            var unit = _context.Units.FirstOrDefault(x => x.ID_Unit == id);

            if (unit != null)
            {
                _context.Units.Remove(unit);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Unit> GetAllUnits()
        {
            var result = _context.Units
                .Select(x => new Unit()
                {
                    ID_Unit = x.ID_Unit,
                    Unit_name = x.Unit_name,
                }).ToList();

            return result;
        }

        public Unit GetUnit(int id)
        {
            var result = _context.Units
                .Where(x => x.ID_Unit == id)
                .Select(x => new Unit()
                {
                    ID_Unit = x.ID_Unit,
                    Unit_name = x.Unit_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateUnit(int id, Unit model)
        {
            var unit = _context.Units.FirstOrDefault(x => x.ID_Unit == id);

            if (unit != null)
            {
                unit.Unit_name = model.Unit_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        int AddNewUnit(UnitViewModel model);
        List<UnitViewModel> GetAllUnits();
        UnitViewModel GetUnit(int id);
        bool UpdateUnit(int id, UnitViewModel model);
        bool DeleteUnit(int id);
    }
}

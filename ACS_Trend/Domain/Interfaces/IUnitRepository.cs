using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        int AddNewUnit(Unit model);
        List<Unit> GetAllUnits();
        Unit GetUnit(int id);
        bool UpdateUnit(int id, Unit model);
        bool DeleteUnit(int id);
    }
}

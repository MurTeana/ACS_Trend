using ACS_Trend.Models.DB.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Interfaces
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        IEnumerable<Unit> GetAllUnits();
    }
}

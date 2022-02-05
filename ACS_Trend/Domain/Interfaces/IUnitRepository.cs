using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        IEnumerable<Unit> GetAllUnits();
    }
}

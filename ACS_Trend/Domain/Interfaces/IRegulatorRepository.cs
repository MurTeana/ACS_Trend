using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IRegulatorRepository : IGenericRepository<Regulator>
    {
        int AddNewRegulator(Regulator model);
        List<Regulator> GetAllRegulators();
        Regulator GetRegulator(int id);
        bool UpdateRegulator(int id, Regulator model);
        bool DeleteRegulator(int id);
    }
}

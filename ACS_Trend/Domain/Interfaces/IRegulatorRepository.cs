using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IRegulatorRepository : IGenericRepository<Regulator>
    {
        void AddNewRegulator(Regulator regulator);
        List<Regulator> GetAllRegulators();
    }
}

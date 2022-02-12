using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IRegulatorRepository : IGenericRepository<Regulator>
    {
        int AddNewRegulator(RegulatorViewModel model);
        List<RegulatorViewModel> GetAllRegulators();
        RegulatorViewModel GetRegulator(int id);
        bool UpdateRegulator(int id, RegulatorViewModel model);
        bool DeleteRegulator(int id);
    }
}

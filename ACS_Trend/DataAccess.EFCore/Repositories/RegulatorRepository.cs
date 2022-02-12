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
            throw new System.NotImplementedException();
        }

        public bool DeleteRegulator(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<RegulatorViewModel> GetAllRegulators()
        {
            throw new System.NotImplementedException();
        }

        public RegulatorViewModel GetRegulator(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateRegulator(int id, RegulatorViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}

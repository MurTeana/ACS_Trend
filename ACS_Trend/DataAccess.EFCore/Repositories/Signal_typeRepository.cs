using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Signal_typeRepository : GenericRepository<Signal_type>, ISignal_typeRepository
    {
        public Signal_typeRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewSignal_type(Signal_typeViewModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSignal_type(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Signal_typeViewModel> GetAllSignal_types()
        {
            throw new System.NotImplementedException();
        }

        public Signal_typeViewModel GetSignal_type(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateSignal_type(int id, Signal_typeViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}

using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ISignal_typeRepository : IGenericRepository<Signal_type>
    {
        int AddNewSignal_type(Signal_typeViewModel model);
        List<Signal_typeViewModel> GetAllSignal_types();
        Signal_typeViewModel GetSignal_type(int id);
        bool UpdateSignal_type(int id, Signal_typeViewModel model);
        bool DeleteSignal_type(int id);
    }
}

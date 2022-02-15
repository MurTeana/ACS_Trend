using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ISignal_typeRepository : IGenericRepository<Signal_type>
    {
        int AddNewSignal_type(Signal_type model);
        List<Signal_type> GetAllSignal_types();
        Signal_type GetSignal_type(int id);
        bool UpdateSignal_type(int id, Signal_type model);
        bool DeleteSignal_type(int id);
    }
}

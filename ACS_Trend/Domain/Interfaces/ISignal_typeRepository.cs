using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ISignal_typeRepository : IGenericRepository<Signal_type>
    {
        void AddNewSignal_type(Signal_type signal_Type);
        List<Signal_type> GetAllSignal_types();
    }
}

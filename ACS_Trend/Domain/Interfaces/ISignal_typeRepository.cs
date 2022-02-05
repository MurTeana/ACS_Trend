using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ISignal_typeRepository
    {
        IEnumerable<Signal_type> GetAllSignal_types();
    }
}

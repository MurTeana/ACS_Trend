using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IStation_typeRepository
    {
        IEnumerable<Station_type> GetAllStation_types();
    }
}

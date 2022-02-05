using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITransient_characteristicRepository
    {
        IEnumerable<Transient_characteristic> GetAllTransient_characteristics();
    }
}

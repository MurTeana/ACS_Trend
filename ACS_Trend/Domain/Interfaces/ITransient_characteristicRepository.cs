using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITransient_characteristicRepository : IGenericRepository<Transient_characteristic>
    {
        void AddNewTransient_characteristic(Transient_characteristic transient_Characteristic);
        List<Transient_characteristic> GetAllTransient_characteristics();
    }
}

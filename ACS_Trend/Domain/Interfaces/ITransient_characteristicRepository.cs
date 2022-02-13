using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITransient_characteristicRepository : IGenericRepository<Transient_characteristicViewModel>
    {
        int AddNewTransient_characteristic(Transient_characteristicViewModel model);
        List<TrendPointViewModel> AddNewListTransient_characteristics(Transient_characteristicViewModel Transient_characteristic);
        List<Transient_characteristicViewModel> GetAllTransient_characteristics();
        Transient_characteristicViewModel GetTransient_characteristic(int id);
        bool UpdateTransient_characteristic(int id, Transient_characteristicViewModel model);
        bool DeleteTransient_characteristic(int id);
    }
}

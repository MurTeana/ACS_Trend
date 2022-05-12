using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITransient_characteristicPointRepository : IGenericRepository<Transient_characteristicPointViewModel>
    {
        int AddNewTransient_characteristicPoint(Transient_characteristicPointViewModel model);
        int AddNewListTransient_characteristicPoints(Transient_characteristicPointViewModel Transient_characteristicPoints);
        List<Transient_characteristicPointViewModel> GetAllTransient_characteristicPoints();
        Transient_characteristicPointViewModel GetTransient_characteristicPoint(int id);
        List<Transient_characteristicPointViewModel> GetListTransient_characteristicPoints(int stid, int trpid);
        bool UpdateTransient_characteristicPoint(int id, Transient_characteristicPointViewModel model);
        bool DeleteTransient_characteristicPoint(int id);
    }
}

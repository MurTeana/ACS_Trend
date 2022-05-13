using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITransient_characteristicPointRepository : IGenericRepository<Transient_characteristicPointViewModel>
    {
        int AddNewListTransient_characteristicPoints(Transient_characteristicPointViewModel Transient_characteristicPoints);
        List<List<Transient_characteristicPoint>> FindTransCharByTrendID(int trendID);  
    }
}

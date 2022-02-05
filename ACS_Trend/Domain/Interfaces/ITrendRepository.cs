using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface ITrendRepository
    {
        IEnumerable<Trend> GetAllTrends();
    }
}

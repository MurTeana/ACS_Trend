using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_objectRepository
    {
        IEnumerable<Control_object> GetAllControl_objects();
    }
}

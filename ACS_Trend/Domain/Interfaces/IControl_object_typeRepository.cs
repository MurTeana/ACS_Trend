using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_object_typeRepository
    {
        IEnumerable<Control_object_type> GetAllControl_object_types();
    }
}

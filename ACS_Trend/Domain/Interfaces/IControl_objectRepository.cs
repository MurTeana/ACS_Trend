using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_objectRepository : IGenericRepository<Control_object>
    {
        void AddNewControl_object(Control_object control_Object);
        List<Control_object> GetAllControl_objects();
    }
}

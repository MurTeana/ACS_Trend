using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_objectRepository : IGenericRepository<Control_object>
    {
        int AddNewControl_object(Control_object model);
        List<Control_object> GetAllControl_objects();
        Control_object GetControl_object(int id);
        bool UpdateControl_object(int id, Control_object model);
        bool DeleteControl_object(int id);
    }
}

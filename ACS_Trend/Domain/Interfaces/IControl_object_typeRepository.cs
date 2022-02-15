using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_object_typeRepository : IGenericRepository<Control_object_type>
    {
        int AddNewControl_object_type(Control_object_type model);
        List<Control_object_type> GetAllControl_object_types();
        Control_object_type GetControl_object_type(int id);
        bool UpdateControl_object_type(int id, Control_object_type model);
        bool DeleteControl_object_type(int id);
    }
}

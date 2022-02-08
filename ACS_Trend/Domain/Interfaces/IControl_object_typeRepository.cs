using ACS_Trend.Domain.Entities;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_object_typeRepository : IGenericRepository<Control_object_type>
    {
        void AddNewControl_object_type(Control_object_type control_Object_Type);
        List<Control_object_type> GetAllControl_object_types();
    }
}

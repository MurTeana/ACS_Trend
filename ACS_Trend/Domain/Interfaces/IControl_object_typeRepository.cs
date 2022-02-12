using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_object_typeRepository : IGenericRepository<Control_object_typeViewModel>
    {
        int AddNewControl_object_type(Control_object_typeViewModel model);
        List<Control_object_typeViewModel> GetAllControl_object_types();
        Control_object_typeViewModel GetControl_object_type(int id);
        bool UpdateControl_object_type(int id, Control_object_typeViewModel model);
        bool DeleteControl_object_type(int id);
    }
}

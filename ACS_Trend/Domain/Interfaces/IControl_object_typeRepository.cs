using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_object_typeRepository : IGenericRepository<Control_object_typeViewModel>
    {
        int AddNewControl_object_type(Control_object_typeViewModel control_Object_Type);
        public List<Control_object_typeViewModel> GetAllControl_object_types();

        public Control_object_typeViewModel GetControl_object_type(int id);

        public bool UpdateControl_object_type(int id, Control_object_typeViewModel model);
        public bool DeleteControl_object_type(int id);
    }
}

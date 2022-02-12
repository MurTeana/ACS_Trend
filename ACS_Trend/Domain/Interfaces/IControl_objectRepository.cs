using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_objectRepository : IGenericRepository<Control_objectViewModel>
    {
        void AddNewControl_object(Control_objectViewModel model);
        List<Control_objectViewModel> GetAllControl_objects();
        Control_objectViewModel GetControl_object(int id);
        bool UpdateControl_object(int id, Control_objectViewModel model);
        bool DeleteControl_object(int id);
    }
}

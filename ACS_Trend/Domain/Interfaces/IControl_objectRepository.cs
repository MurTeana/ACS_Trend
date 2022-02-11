using ACS_Trend.Models;
using System.Collections.Generic;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IControl_objectRepository : IGenericRepository<Control_objectViewModel>
    {
        void AddNewControl_object(Control_objectViewModel control_Object);
        List<Control_objectViewModel> GetAllControl_objects();

        public Control_objectViewModel GetControl_object(int id);

        public bool UpdateControl_object(int id, Control_objectViewModel model);
        public bool DeleteControl_object(int id);
    }
}

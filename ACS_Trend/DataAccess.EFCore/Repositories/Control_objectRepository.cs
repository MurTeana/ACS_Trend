using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Control_objectRepository : GenericRepository<Control_objectViewModel>, IControl_objectRepository
    {
        public Control_objectRepository(ApplicationContext context) : base(context)
        {
        }
        public void AddNewControl_object(Control_objectViewModel control_Object)
        {
            _context.Set<Control_objectViewModel>().Add(control_Object);
            _context.SaveChanges();
        }
        public List<Control_objectViewModel> GetAllControl_objects()
        {
            return _context.Set<Control_objectViewModel>().ToList();
        }

        public Control_objectViewModel GetControl_object(int id)
        {

            return new Control_objectViewModel();
        }

        public bool UpdateControl_object(int id, Control_objectViewModel model)
        {
            return true;
        }

        public bool DeleteControl_object(int id)
        {
            return true;
        }
    }
}

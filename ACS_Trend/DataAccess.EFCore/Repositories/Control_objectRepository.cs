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
        public int AddNewControl_object(Control_objectViewModel model)
        {
            Control_object Control_object = new Control_object()
            {
                Control_object_name = model.Control_object_name
            };

            _context.Control_objects.Add(Control_object);
            _context.SaveChanges();

            return Control_object.ID_Control_object;
        }

        public bool DeleteControl_object(int id)
        {
            var Control_object = _context.Control_objects.FirstOrDefault(x => x.ID_Control_object == id);

            if (Control_object != null)
            {
                _context.Control_objects.Remove(Control_object);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Control_objectViewModel> GetAllControl_objects()
        {
            var result = _context.Control_objects
                .Select(x => new Control_objectViewModel()
                {
                    ID_Control_object = x.ID_Control_object,
                    Control_object_name = x.Control_object_name,
                }).ToList();

            return result;
        }

        public Control_objectViewModel GetControl_object(int id)
        {
            var result = _context.Control_objects
                .Where(x => x.ID_Control_object == id)
                .Select(x => new Control_objectViewModel()
                {
                    ID_Control_object = x.ID_Control_object,
                    Control_object_name = x.Control_object_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateControl_object(int id, Control_objectViewModel model)
        {
            var Control_object = _context.Control_objects.FirstOrDefault(x => x.ID_Control_object == id);

            if (Control_object != null)
            {
                Control_object.Control_object_name = model.Control_object_name;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

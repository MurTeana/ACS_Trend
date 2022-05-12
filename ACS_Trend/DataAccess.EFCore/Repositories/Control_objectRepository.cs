using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Control_objectRepository : GenericRepository<Control_object>, IControl_objectRepository
    {
        public Control_objectRepository(ApplicationContext context) : base(context)
        {
        }
        public int AddNewControl_object(Control_object model)
        {
            Control_object Control_object = new Control_object()
            {
                Control_object_name = model.Control_object_name,
                Extend_information = model.Extend_information,
                CO_ID_Control_object_type = model.CO_ID_Control_object_type
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

        public List<Control_object> GetAllControl_objects()
        {
            var result = _context.Control_objects
                .Select(x => new Control_object()
                {
                    ID_Control_object = x.ID_Control_object,
                    Control_object_name = x.Control_object_name,
                    Extend_information = x.Extend_information,
                    CO_ID_Control_object_type = x.CO_ID_Control_object_type,
                    Control_object_type = x.Control_object_type
                }).ToList();

            return result;
        }

        public Control_object GetControl_object(int id)
        {
            var result = _context.Control_objects
                .Where(x => x.ID_Control_object == id)
                .Select(x => new Control_object()
                {
                    ID_Control_object = x.ID_Control_object,
                    Control_object_name = x.Control_object_name,
                    Extend_information = x.Extend_information,
                    CO_ID_Control_object_type = x.CO_ID_Control_object_type,
                    Control_object_type = x.Control_object_type
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateControl_object(int id, Control_object model)
        {
            var Control_object = _context.Control_objects.FirstOrDefault(x => x.ID_Control_object == id);

            if (Control_object != null)
            {
                Control_object.Control_object_name = model.Control_object_name;
                Control_object.Extend_information= model.Extend_information;
                Control_object.CO_ID_Control_object_type = model.CO_ID_Control_object_type;
            }

            _context.SaveChanges();
            return true;
        }
    }
}

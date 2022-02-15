using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Control_object_typeRepository : GenericRepository<Control_object_type>, IControl_object_typeRepository
    {
        public Control_object_typeRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewControl_object_type(Control_object_type model)
        {
            _context.Control_object_types.Add(model);
            _context.SaveChanges();

            return model.ID_Control_object_type;
        }

        public List<Control_object_type> GetAllControl_object_types()
        {
            var result = _context.Control_object_types
            .Select(x => new Control_object_type()
            {
                ID_Control_object_type = x.ID_Control_object_type,
                Control_object_type_name = x.Control_object_type_name,
            }).ToList();

            return result;
        }

        public Control_object_type GetControl_object_type(int id)
        {
            var result = _context.Control_object_types
                .Where(x => x.ID_Control_object_type == id)
                .Select(x => new Control_object_type()
                {
                    ID_Control_object_type = x.ID_Control_object_type,
                    Control_object_type_name = x.Control_object_type_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateControl_object_type(int id, Control_object_type model)
        {
            var co_t = _context.Control_object_types.FirstOrDefault(x => x.ID_Control_object_type == id);

            if (co_t != null)
            {
                co_t.Control_object_type_name = model.Control_object_type_name;
            }

            _context.SaveChanges();
            return true;
        }

        public bool DeleteControl_object_type(int id)
        {
            var co_t = _context.Control_object_types.FirstOrDefault(x => x.ID_Control_object_type == id);

            if (co_t != null)
            {
                _context.Control_object_types.Remove(co_t);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}

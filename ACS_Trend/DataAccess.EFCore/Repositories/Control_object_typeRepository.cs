using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.DataAccess.EFCore.Repositories
{
    public class Control_object_typeRepository : GenericRepository<Control_object_typeViewModel>, IControl_object_typeRepository
    {
        public Control_object_typeRepository(ApplicationContext context) : base(context)
        {
        }

        public int AddNewControl_object_type(Control_object_typeViewModel model)
        {
            Control_object_type co_t = new Control_object_type()
            {
                Control_object_type_name = model.Control_object_type_name
            };

            _context.Control_object_types.Add(co_t);
            _context.SaveChanges();

            return co_t.ID_Control_object_type;
        }

        public List<Control_object_typeViewModel> GetAllControl_object_types()
        {
            var result = _context.Control_object_types
            .Select(x => new Control_object_typeViewModel()
            {
                ID_Control_object_type = x.ID_Control_object_type,
                Control_object_type_name = x.Control_object_type_name,
            }).ToList();

            return result;
        }

        public Control_object_typeViewModel GetControl_object_type(int id)
        {
            var result = _context.Control_object_types
                .Where(x => x.ID_Control_object_type == id)
                .Select(x => new Control_object_typeViewModel()
                {
                    ID_Control_object_type = x.ID_Control_object_type,
                    Control_object_type_name = x.Control_object_type_name
                }).FirstOrDefault();

            return result;
        }

        public bool UpdateControl_object_type(int id, Control_object_typeViewModel model)
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

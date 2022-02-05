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
        public IEnumerable<Control_object_type> GetAllControl_object_types()
        {
            return _context.Set<Control_object_type>().ToList(); ;
        }
    }
}

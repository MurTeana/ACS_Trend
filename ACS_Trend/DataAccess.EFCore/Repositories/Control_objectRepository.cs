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
        public IEnumerable<Control_object> GetAllControl_objects()
        {
            return _context.Set<Control_object>().ToList(); ;
        }
    }
}

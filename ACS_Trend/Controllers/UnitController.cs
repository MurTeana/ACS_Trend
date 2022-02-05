using ACS_Trend.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACS_Trend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetAllUnits([FromQuery] int count)
        {
            var allUnits = _unitOfWork.Units.GetAllUnits();
            return Ok(allUnits);
        }
    }
}

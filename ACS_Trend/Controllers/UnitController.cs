using ACS_Trend.Domain.Entities;
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

        [HttpGet]
        public IActionResult GetAllUnits()
        {
            var allUnits = _unitOfWork.Units.GetAllUnits();
            return Ok(allUnits);
        }

        [HttpPost]
        public IActionResult AddNewUnit(Unit unit)
        {
            _unitOfWork.Units.AddNewUnit(unit);
            return Ok();
        }
    }
}

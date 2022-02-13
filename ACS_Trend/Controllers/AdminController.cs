using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ACS_Trend.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult AdminDB()
        {
            List<EntityDB> entitiesList = new List<EntityDB>
            {
                new EntityDB {Id = 1, Entity = "Тип объекта управления (Control_object_type)", Method = "CONTROL_OBJECT_TYPES_GetAll" },
                new EntityDB {Id = 3, Entity = "Регулятор (Regulators)", Method = "REGULATORS_GetAll" },
                new EntityDB {Id = 4, Entity = "Тип сигнала тренда (Signal_type)", Method = "SIGNAL_TYPES_GetAll" },
                new EntityDB {Id = 12, Entity = "Единицы измерения (Units)", Method = "UNITS_GetAll" },                
            };

            ViewBag.EntitiesList = entitiesList;

            return View();
        }

        // 1 - CONTROL_OBJECT_TYPES
        public ActionResult CONTROL_OBJECT_TYPES_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CONTROL_OBJECT_TYPES_Create(Control_object_typeViewModel model)
        {
            _unitOfWork.Control_object_types.AddNewControl_object_type(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult CONTROL_OBJECT_TYPES_GetAll()
        {
            var result = _unitOfWork.Control_object_types.GetAllControl_object_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult CONTROL_OBJECT_TYPES_Details(int id)
        {
            var result = _unitOfWork.Control_object_types.GetControl_object_type(id);
            return View(result);
        }

        public ActionResult CONTROL_OBJECT_TYPES_Edit(int id)
        {
            var unit = _unitOfWork.Control_object_types.GetControl_object_type(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult CONTROL_OBJECT_TYPES_Edit(Control_object_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Control_object_types.UpdateControl_object_type(model.ID_Control_object_type, model);

                return RedirectToAction("CONTROL_OBJECT_TYPES_GetAll");
            }

            return View();
        }

        public ActionResult CONTROL_OBJECT_TYPES_Delete(int id)
        {
            _unitOfWork.Control_object_types.DeleteControl_object_type(id);

            return RedirectToAction("CONTROL_OBJECT_TYPES_GetAll");
        }

        // 3 - REGULATORS
        public ActionResult REGULATORS_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult REGULATORS_Create(RegulatorViewModel model)
        {
            _unitOfWork.Regulators.AddNewRegulator(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult REGULATORS_GetAll()
        {
            var result = _unitOfWork.Regulators.GetAllRegulators();
            return View(result);
        }

        [HttpGet]
        public ActionResult REGULATORS_Details(int id)
        {
            var result = _unitOfWork.Regulators.GetRegulator(id);
            return View(result);
        }

        public ActionResult REGULATORS_Edit(int id)
        {
            var unit = _unitOfWork.Regulators.GetRegulator(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult REGULATORS_Edit(RegulatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Regulators.UpdateRegulator(model.ID_Regulator, model);

                return RedirectToAction("REGULATORS_GetAll");
            }

            return View();
        }

        public ActionResult REGULATORS_Delete(int id)
        {
            _unitOfWork.Regulators.DeleteRegulator(id);

            return RedirectToAction("REGULATORS_GetAll");
        }

        // 4 - SIGNAL_TYPES
        public ActionResult SIGNAL_TYPES_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SIGNAL_TYPES_Create(Signal_typeViewModel model)
        {
            _unitOfWork.Signal_types.AddNewSignal_type(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult SIGNAL_TYPES_GetAll()
        {
            var result = _unitOfWork.Signal_types.GetAllSignal_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult SIGNAL_TYPES_Details(int id)
        {
            var result = _unitOfWork.Signal_types.GetSignal_type(id);
            return View(result);
        }

        public ActionResult SIGNAL_TYPES_Edit(int id)
        {
            var unit = _unitOfWork.Signal_types.GetSignal_type(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult SIGNAL_TYPES_Edit(Signal_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Signal_types.UpdateSignal_type(model.ID_Signal_type, model);

                return RedirectToAction("SIGNAL_TYPES_GetAll");
            }

            return View();
        }

        public ActionResult SIGNAL_TYPES_Delete(int id)
        {
            _unitOfWork.Signal_types.DeleteSignal_type(id);

            return RedirectToAction("SIGNAL_TYPES_GetAll");
        }

        // 12 - UNITS
        public ActionResult UNITS_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UNITS_Create(UnitViewModel model)
        {
            _unitOfWork.Units.AddNewUnit(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult UNITS_GetAll()
        {
            var result = _unitOfWork.Units.GetAllUnits();
            return View(result);
        }

        [HttpGet]
        public ActionResult UNITS_Details(int id)
        {
            var result = _unitOfWork.Units.GetUnit(id);
            return View(result);
        }

        public ActionResult UNITS_Edit(int id)
        {
            var unit = _unitOfWork.Units.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult UNITS_Edit(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Units.UpdateUnit(model.ID_Unit, model);

                return RedirectToAction("UNITS_GetAll");
            }

            return View();
        }

        public ActionResult UNITS_Delete(int id)
        {
            _unitOfWork.Units.DeleteUnit(id);

            return RedirectToAction("UNITS_GetAll");
        }
    }
}

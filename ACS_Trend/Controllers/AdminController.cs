﻿using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                new EntityDB {Id = 1, Entity = "Типы объектов управления (Control_object_types)", Method = "CONTROL_OBJECT_TYPES_GetAll" },
                new EntityDB {Id = 2, Entity = "Объекты управления (Control_objects)", Method = "CONTROL_OBJECTS_GetAll" },
                new EntityDB {Id = 3, Entity = "Регуляторы (Regulators)", Method = "REGULATORS_GetAll" },
                new EntityDB {Id = 4, Entity = "Типы сигналов тренда (Signal_types)", Method = "SIGNAL_TYPES_GetAll" },
                new EntityDB {Id = 5, Entity = "Станции (Stations)", Method = "STATIONS_GetAll" },
                new EntityDB {Id = 6, Entity = "Типы станций (Station_types)", Method = "STATION_TYPES_GetAll" },
                new EntityDB {Id = 10, Entity = "Типы параметра тренда (Trend_parameter_types)", Method = "TREND_PARAMETER_TYPES_GetAll" },
                new EntityDB {Id = 11, Entity = "Точки тренда (TrendPoints)", Method = "TREND_POINTS_GetAll" },
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
            var result = _unitOfWork.Control_object_types.GetControl_object_type(id);
            return View(result);
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

        // 2 - CONTROL_OBJECTS
        public ActionResult CONTROL_OBJECTS_Create()
        {
            ViewBag.Control_object_types = new SelectList(_unitOfWork.Control_object_types.GetAllControl_object_types(), "ID_Control_object_type", "Control_object_type_name");

            return View();
        }

        [HttpPost]
        public ActionResult CONTROL_OBJECTS_Create(Control_objectViewModel model)
        {
            ViewBag.Control_object_types = new SelectList(_unitOfWork.Control_object_types.GetAllControl_object_types(), "ID_Control_object_type", "Control_object_type_name");

            _unitOfWork.Control_objects.AddNewControl_object(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult CONTROL_OBJECTS_GetAll()
        {
            var result = _unitOfWork.Control_objects.GetAllControl_objects();
            return View(result);
        }

        [HttpGet]
        public ActionResult CONTROL_OBJECTS_Details(int id)
        {
            var result = _unitOfWork.Control_objects.GetControl_object(id);
            return View(result);
        }

        public ActionResult CONTROL_OBJECTS_Edit(int id)
        {
            var result = _unitOfWork.Control_objects.GetControl_object(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult CONTROL_OBJECTS_Edit(Control_objectViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Control_objects.UpdateControl_object(model.ID_Control_object, model);

                return RedirectToAction("CONTROL_OBJECT_TYPES_GetAll");
            }

            return View();
        }

        public ActionResult CONTROL_OBJECTS_Delete(int id)
        {
            _unitOfWork.Control_objects.DeleteControl_object(id);

            return RedirectToAction("CONTROL_OBJECTS_GetAll");
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
            var result = _unitOfWork.Regulators.GetRegulator(id);
            return View(result);
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
            var result = _unitOfWork.Signal_types.GetSignal_type(id);
            return View(result);
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

        // 5 - STATIONS
        public ActionResult STATIONS_Create()
        {
            ViewBag.Station_Types = new SelectList(_unitOfWork.Station_types.GetAllStation_types(), "ID_Station_type", "Station_type_name");

            return View();
        }

        [HttpPost]
        public ActionResult STATIONS_Create(StationViewModel model)
        {
            ViewBag.Station_Types = new SelectList(_unitOfWork.Station_types.GetAllStation_types(), "ID_Station_type", "Station_type_name");

            _unitOfWork.Stations.AddNewStation(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult STATIONS_GetAll()
        {
            var result = _unitOfWork.Stations.GetAllStations();
            return View(result);
        }

        [HttpGet]
        public ActionResult STATIONS_Details(int id)
        {
            var result = _unitOfWork.Stations.GetStation(id);
            return View(result);
        }

        public ActionResult STATIONS_Edit(int id)
        {
            var result = _unitOfWork.Stations.GetStation(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult STATIONS_Edit(StationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Stations.UpdateStation(model.ID_Station, model);

                return RedirectToAction("STATIONS_GetAll");
            }

            return View();
        }

        public ActionResult STATIONS_Delete(int id)
        {
            _unitOfWork.Stations.DeleteStation(id);

            return RedirectToAction("STATIONS_GetAll");
        }

        // 6 - STATIONS_TYPES
        public ActionResult STATION_TYPES_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult STATION_TYPES_Create(Station_typeViewModel model)
        {
            _unitOfWork.Station_types.AddNewStation_type(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult STATION_TYPES_GetAll()
        {
            var result = _unitOfWork.Station_types.GetAllStation_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult STATION_TYPES_Details(int id)
        {
            var result = _unitOfWork.Station_types.GetStation_type(id);
            return View(result);
        }

        public ActionResult STATION_TYPES_Edit(int id)
        {
            var result = _unitOfWork.Station_types.GetStation_type(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult STATION_TYPES_Edit(Station_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Station_types.UpdateStation_type(model.ID_Station_type, model);

                return RedirectToAction("STATION_TYPES_GetAll");
            }

            return View();
        }

        public ActionResult STATION_TYPES_Delete(int id)
        {
            _unitOfWork.Station_types.DeleteStation_type(id);

            return RedirectToAction("STATION_TYPES_GetAll");
        }

        // 10 - TREND_PARAMETER_TYPES
        public ActionResult TREND_PARAMETER_TYPES_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TREND_PARAMETER_TYPES_Create(Trend_parameter_typeViewModel model)
        {
            _unitOfWork.Trend_parameter_types.AddNewTrend_parameter_type(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult TREND_PARAMETER_TYPES_GetAll()
        {
            var result = _unitOfWork.Trend_parameter_types.GetAllTrend_parameter_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult TREND_PARAMETER_TYPES_Details(int id)
        {
            var result = _unitOfWork.Trend_parameter_types.GetTrend_parameter_type(id);
            return View(result);
        }

        public ActionResult TREND_PARAMETER_TYPES_Edit(int id)
        {
            var result = _unitOfWork.Trend_parameter_types.GetTrend_parameter_type(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult TREND_PARAMETER_TYPES_Edit(Trend_parameter_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Trend_parameter_types.UpdateTrend_parameter_type(model.ID_Trend_parameter_type, model);

                return RedirectToAction("TREND_PARAMETER_TYPES_GetAll");
            }

            return View();
        }

        public ActionResult TREND_PARAMETER_TYPES_Delete(int id)
        {
            _unitOfWork.Trend_parameter_types.DeleteTrend_parameter_type(id);

            return RedirectToAction("TREND_PARAMETER_TYPES_GetAll");
        }

        // 11 - TREND_POINTS
        public ActionResult TREND_POINTS_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TREND_POINTS_Create(TrendPointViewModel model)
        {
            _unitOfWork.TrendPoints.AddNewTrendPoint(model);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult TREND_POINTS_GetAll()
        {
            var result = _unitOfWork.TrendPoints.GetAllTrendPoints();
            return View(result);
        }

        [HttpGet]
        public ActionResult TREND_POINTS_Details(int id)
        {
            var result = _unitOfWork.TrendPoints.GetTrendPoint(id);
            return View(result);
        }

        public ActionResult TREND_POINTS_Edit(int id)
        {
            var result = _unitOfWork.TrendPoints.GetTrendPoint(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult TREND_POINTS_Edit(TrendPointViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TrendPoints.UpdateTrendPoint(model.ID_TrendPoint, model);

                return RedirectToAction("UNITS_GetAll");
            }

            return View();
        }

        public ActionResult TREND_POINTS_Delete(int id)
        {
            _unitOfWork.TrendPoints.DeleteTrendPoint(id);

            return RedirectToAction("TREND_POINTS_GetAll");
        }

        // 12 - UNITS
        public ActionResult UNITS_Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UNITS_Create(Unit model)
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
            var result = _unitOfWork.Units.GetUnit(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UNITS_Edit(Unit model)
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
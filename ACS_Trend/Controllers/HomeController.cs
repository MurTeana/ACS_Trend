using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace ACS_Trend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult AdminDB()
        {
            return View();
        }

        // GET: Home

        // UNIT
        public ActionResult CreateUnit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUnit(UnitViewModel unit)
        {
            _unitOfWork.Units.AddNewUnit(unit);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }
                       
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUnits()
        {
            var result = _unitOfWork.Units.GetAllUnits();
            return View(result);
        }

        [HttpGet]
        public ActionResult Details_Unit(int id)
        {
            var result = _unitOfWork.Units.GetUnit(id);
            return View(result);
        }

        public ActionResult EditUnit(int id)
        {
            var unit = _unitOfWork.Units.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public ActionResult EditUnit(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Units.UpdateUnit(model.ID_Unit, model);

                return RedirectToAction("GetAllUnits");
            }

            return View();
        }

        public ActionResult DeleteUnit(int id)
        {
            _unitOfWork.Units.DeleteUnit(id);

            return RedirectToAction("GetAllUnits");
        }

        // TREND

        public ActionResult CreateTrend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrend(TrendViewModel trend)
        {
            _unitOfWork.Trends.AddNewTrend(trend);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }
                       
            return View();
        }

        [HttpGet]
        public ActionResult GetAllTrends()
        {
            var result = _unitOfWork.Trends.GetAllTrends();
            return View(result);
        }

        public ActionResult CreateStation()
        {
            ViewBag.Station_Types = new SelectList(_unitOfWork.Station_types.GetAllStation_types(), "ID_Station_type", "StationType");
            return View();
        }

        [HttpPost]
        public ActionResult CreateStation(StationViewModel station)
        {
            ViewBag.Station_Types = new SelectList(_unitOfWork.Station_types.GetAllStation_types(), "ID_Station_type", "StationType");

            int id = _unitOfWork.Stations.AddNewStation(station);

            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }                  
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetAllStations()
        {
            var result = _unitOfWork.Stations.GetAllStations();
            return View(result);
        }

        // STATION_TYPE

        public ActionResult CreateStation_type()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStation_type(Station_typeViewModel station_Type)
        {
            _unitOfWork.Station_types.AddNewStation_type(station_Type);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetAllStation_types()
        {
            var result = _unitOfWork.Station_types.GetAllStation_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult Details_Station_Type(int id)
        {
            var result = _unitOfWork.Station_types.GetStation_Type(id);
            return View(result);
        }

        public ActionResult EditStation_type(int id)
        {
            var st_t = _unitOfWork.Station_types.GetStation_Type(id);
            return View(st_t);
        }

        [HttpPost]
        public ActionResult EditStation_type(Station_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Station_types.UpdateStation_Type(model.ID_Station_type, model);

                return RedirectToAction("GetAllStation_types");
            }

            return View();
        }

        public ActionResult DeleteStation_type(int id)
        {
            _unitOfWork.Station_types.DeleteStation_Type(id);

            return RedirectToAction("GetAllStation_types");
        }


        // CONTROL_OBJECT_TYPE

        public ActionResult CreateControl_object_type()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateControl_object_type(Control_object_typeViewModel control_object_type)
        {
            _unitOfWork.Control_object_types.AddNewControl_object_type(control_object_type);

            if (ModelState.IsValid)
            {
                ModelState.Clear();
                ViewBag.Issuccess = "Data Added";
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetAllControl_object_types()
        {
            var result = _unitOfWork.Control_object_types.GetAllControl_object_types();
            return View(result);
        }

        [HttpGet]
        public ActionResult Details_Control_object_type(int id)
        {
            var result = _unitOfWork.Control_object_types.GetControl_object_type(id);
            return View(result);
        }

        public ActionResult EditControl_object_type(int id)
        {
            var co_t = _unitOfWork.Control_object_types.GetControl_object_type(id);
            return View(co_t);
        }

        [HttpPost]
        public ActionResult EditControl_object_type(Control_object_typeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Control_object_types.UpdateControl_object_type(model.ID_Control_object_type, model);

                return RedirectToAction("GetAllControl_object_types");
            }

            return View();
        }

        public ActionResult DeleteControl_object_type(int id)
        {
            _unitOfWork.Control_object_types.DeleteControl_object_type(id);

            return RedirectToAction("GetAllControl_object_types");
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var masterModel = new HomeIndexViewModel();

            // line chart
            var lineChartData = GetLineChartData();
            masterModel.LineChartData = lineChartData;

            return View(masterModel);
        }
        private LineChartViewModel GetLineChartData()
        {
            var lineChartData = new LineChartViewModel();

            lineChartData.title.text = "Тренд входной динамической характеристики теплоэнергетичеcкого оборудования";
            lineChartData.subtitle.text = "Расход пара";

            lineChartData.xAxis.title.text = "TITLE_X";
            lineChartData.yAxis.title.text = "TITLE_Y";

            lineChartData.plotOptions.line.dataLabels.enabled = true;
            lineChartData.plotOptions.line.enableMouseTracking = true;

            // DATA
            lineChartData.series.name = "Tokyo";
            List<double[]> pointsdata = new List<double[]>();

            for (int i = 0; i < 100; i++)
            {
                var point = new double[] { i, i * 3 };
                pointsdata.Add(point);
            }

            lineChartData.series.data = pointsdata;

            return lineChartData;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

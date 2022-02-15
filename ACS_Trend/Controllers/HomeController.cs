using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace ACS_Trend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // TRENDPOINT
        [HttpGet]
        public ActionResult GetAllTrendPoints()
        {
            var result = _unitOfWork.TrendPoints.GetAllTrendPoints();
            return View(result);
        }

        public ActionResult CreateListTrendPoints()
        {
            ViewBag.Stations = new SelectList(_unitOfWork.Stations.GetAllStations(), "ID_Station", "Station_name");
            ViewBag.Units = new SelectList(_unitOfWork.Units.GetAllUnits(), "ID_Unit", "Unit_name");

            List<TrendPointViewModel> points = new List<TrendPointViewModel>();
            points.Add(new TrendPointViewModel { Date_time = 9, Parameter = 9, TP_ID_Trend = 2 });
            points.Add(new TrendPointViewModel { Date_time = 10, Parameter = 10, TP_ID_Trend = 2 });
            points.Add(new TrendPointViewModel { Date_time = 11, Parameter = 11, TP_ID_Trend = 2 });

            ViewBag.Points = points;

            return View();
        }

        [HttpPost]
        public ActionResult CreateListTrendPoints(List<TrendPointViewModel> trendPoints)
        {
            //ViewBag.Trends = new SelectList(_unitOfWork.Trends.GetAllTrends(), "ID_Trend", "T_ID_Station");

            List<TrendPointViewModel> points = new List<TrendPointViewModel>();
            points.Add(new TrendPointViewModel {Date_time = 9, Parameter = 9, TP_ID_Trend = 2 });
            points.Add(new TrendPointViewModel {Date_time = 10, Parameter = 10, TP_ID_Trend = 2 });
            points.Add(new TrendPointViewModel {Date_time = 11, Parameter = 11, TP_ID_Trend = 2 });

            _unitOfWork.TrendPoints.AddNewListTrendPoints(points);

            //if (ModelState.IsValid)
            //{
            //    ModelState.Clear();
            //    ViewBag.Issuccess = "Data Added";
            //}

            return View();
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
        public ActionResult CreateStation_type(Station_type station_Type)
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
            var result = _unitOfWork.Station_types.GetStation_type(id);
            return View(result);
        }

        public ActionResult EditStation_type(int id)
        {
            var st_t = _unitOfWork.Station_types.GetStation_type(id);
            return View(st_t);
        }

        [HttpPost]
        public ActionResult EditStation_type(Station_type model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Station_types.UpdateStation_type(model.ID_Station_type, model);

                return RedirectToAction("GetAllStation_types");
            }

            return View();
        }

        public ActionResult DeleteStation_type(int id)
        {
            _unitOfWork.Station_types.DeleteStation_type(id);

            return RedirectToAction("GetAllStation_types");
        }


        // CONTROL_OBJECT_TYPE
        public ActionResult CreateControl_object_type()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateControl_object_type(Control_object_type control_object_type)
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
        public ActionResult EditControl_object_type(Control_object_type model)
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

        [HttpGet]
        public IActionResult LoadData(List<TestLoadCSV> testdata = null)
        {
            testdata = testdata == null ? new List<TestLoadCSV>() : testdata;
            return View(testdata);
        }

        [HttpPost]
        public IActionResult LoadData(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            };
            #endregion

            var testdatacsv = this.GetDataList(file.FileName);
            return View(testdatacsv);
        }

        private object GetDataList(string fileName)
        {
            List<TestLoadCSV> testdatacsv = new List<TestLoadCSV>();
            #region Read CSV
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var testdatacsvEnt = csv.GetRecord<TestLoadCSV>();
                    testdatacsv.Add(testdatacsvEnt);
                }
            }
            #endregion

            #region Create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\filesto"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(testdatacsv);
            }
            #endregion

            return testdatacsv;
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

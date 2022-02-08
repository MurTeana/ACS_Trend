using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Mvc;
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

        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Unit unit)
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

        public ActionResult AdminDB()
        {
            return View();
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

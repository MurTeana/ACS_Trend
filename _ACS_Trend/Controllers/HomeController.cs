using _ACS_Trend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _ACS_Trend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var masterModel = new HomeIndexVM();

            // line chart
            var lineChartData = GetLineChartData();
            masterModel.LineChartData = lineChartData;

            return View(masterModel);
        }

        private LineChartVM GetLineChartData()
        {
            var lineChartData = new LineChartVM();

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
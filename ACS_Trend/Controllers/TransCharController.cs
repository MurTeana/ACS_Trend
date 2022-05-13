using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Functions;
using ACS_Trend.Models;
using ACS_Trend.Models.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ACS_Trend.Controllers
{
    public class TransCharController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransCharController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult TransChar()
        {
            var masterModel = new HomeIndexViewModel();

            var result = _unitOfWork.Trends.GetAllTrends();
            masterModel.Trends = result;

            // line chart DEFAULT
            var chartsParam_default = new List<LineChartData> { new ChartsParameters().LineChartData_Default };

            IChartData chartData = new ChartData_();

            masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_default);

            return View(masterModel);
        }

        [HttpPost]
        public IActionResult TransChar(int id)
        {
            var masterModel = new HomeIndexViewModel();

            var trend = _unitOfWork.Trends.GetTrend(id);
            masterModel.Trends.Add(trend);

            var listpointsTrChar = _unitOfWork.Transient_characteristicPoints.FindTransCharByTrendID(id);

            // line chart
            var trChars = new List<LineChartData>(); //{ new ChartsParameters().LineChartData_Default };

            int pch = 1;

            foreach (var item in listpointsTrChar)
            {
                var trChar = new ChartsParameters().LineChartData_TransCh;
                trChar.seriesName = "Переходная характеристика - " + pch;

                List<double[]> points = new List<double[]>();

                foreach (var point in item)
                {
                    points.Add(new double[] { point.Date_time, point.Parameter });
                }

                trChar.pointsdata = points;

                trChars.Add(trChar);

                pch++;
            }

            IChartData chartData = new ChartData_();

            masterModel.LineChartData_TransCh = chartData.GetLineChartData(trChars);

            return View(masterModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

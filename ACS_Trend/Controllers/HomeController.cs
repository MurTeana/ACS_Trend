using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Functions;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Index()
        {
            var masterModel = new HomeIndexViewModel();

            // line chart DEFAULT
            IChartData chartData = new ChartData_();
            var lineChartData = chartData.GetLineChartData(null, null, null, null, null, false, null, null);

            masterModel.LineChartData_IN_Source = lineChartData;
            masterModel.LineChartData_IN_Aproxy = lineChartData;
            masterModel.LineChartData_IN_Tg = lineChartData;
            masterModel.LineChartData_IN_Result = lineChartData;

            masterModel.LineChartData_OUT_Source = lineChartData;            
            masterModel.LineChartData_OUT_Aproxy = lineChartData;            
            masterModel.LineChartData_OUT_Tg = lineChartData;
            masterModel.LineChartData_OUT_Result = lineChartData;

            masterModel.K_Approxy = 100;    //6
            masterModel.StartPoint = 1843;  //183

            return View(masterModel);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel masterModel, IFormFile file)
        {
            int qApproxy = masterModel.K_Approxy;
            int startpoint = masterModel.StartPoint;

            if (masterModel.ProcessType == "Построить график")
            {
                // точки графика lineChartDataINSource
                IImportData importData = new ImportData_();
                List<Point> pointslist_IN_SOURCE = importData.ImportPoints(file); 
                
                int pointscount = pointslist_IN_SOURCE.Count;

                List<double[]> pointsdata = new List<double[]>();

                for (int point = 0; point < pointscount; point++)
                {
                    var date_time = Convert.ToDouble(pointslist_IN_SOURCE[point].Date);
                    var parameter = Convert.ToDouble(pointslist_IN_SOURCE[point].Parameter);

                    var pointChart = new double[] { date_time, parameter };
                    pointsdata.Add(pointChart);
                }

                List<double[]> pointsdataOUT = new List<double[]>();

                for (int point = 0; point < pointscount; point++)
                {
                    var date_time = Convert.ToDouble(pointslist_IN_SOURCE[point].Date);
                    var parameter = Convert.ToDouble(pointslist_IN_SOURCE[point].ParameterOUT);

                    var pointChart = new double[] { date_time, parameter };
                    pointsdataOUT.Add(pointChart);
                }


                IMathFunc mathFunc = new MathFunc_();

                // точки графиков
                List<double[]> pointsdataMovAverage = mathFunc.MovAverageList(pointsdata, qApproxy);
                List<double[]> pointsdataTg = mathFunc.DerOfFuncList(pointsdataMovAverage);

                ChartZones chartZones = mathFunc.FindPointList(pointsdataMovAverage, pointsdataTg, startpoint);
                List<int> pointsFind = chartZones.pointFindAll;
                List<double[]> pointsdataResult = new List<double[]>();

                for (int j = 0; j < pointsFind.Count; j++)
                {
                    for (int i = 0; i < pointsdataMovAverage.Count; i++)
                    {
                        if (pointsFind[j] == i && pointsFind[j] != 0)
                        {
                            pointsdataResult.Add(pointsdataMovAverage[i]);
                        }
                    }
                }

                List<double[]> pointsdataOUTMovAverage = mathFunc.MovAverageList(pointsdataOUT, qApproxy);
                List<double[]> pointsdataOUTTg = mathFunc.DerOfFuncList(pointsdataOUTMovAverage);

                ChartZones chartZones_OUT = mathFunc.FindPointList(pointsdataOUTMovAverage, pointsdataOUTTg, startpoint);
                List<int> pointsFind_OUT = chartZones_OUT.pointFindAll;
                List<double[]> pointsdataResult_OUT = new List<double[]>();

                for (int j = 0; j < pointsFind_OUT.Count; j++)
                {
                    for (int i = 0; i < pointsdataOUTMovAverage.Count; i++)
                    {
                        if (pointsFind_OUT[j] == i && pointsFind_OUT[j] != 0)
                        {
                            pointsdataResult_OUT.Add(pointsdataOUTMovAverage[i]);
                        }
                    }
                }

                // графики
                string titleIN = "Тренд входной динамической характеристики теплоэнергетичеcкого оборудования";
                string parameterIN = "parameterIN";
                string seriesNameTP_IN = "Точки тренда входного сигнала";
                string seriesNameTPAver_IN = "Точки сглаженных значений тренда входного сигнала";
                string seriesNameTPTg_IN = "Точки производных графика трендов";
                string seriesNameFP_IN = "Точки найденные";

                string titleOUT = "Тренд выходной динамической характеристики теплоэнергетичеcкого оборудования";
                string parameterOUT = "parameterOUT";
                string seriesNameTP_OUT = "Точки тренда выходного сигнала";
                string seriesNameTPAver_OUT = "Точки сглаженных значений тренда выходного сигнала";
                string seriesNameTPTg_OUT = "Точки производных графика трендов";
                string seriesNameFP_OUT = "Точки найденные";

                string colorMain = "#4682B4"; //255, 99, 71
                string colorFind = "rgba(255,99,71,.5)";

                bool markerEnable = false;
                bool markerEnable2 = true;

                // входной сигнал
                IChartData chartData = new ChartData_();

                masterModel.LineChartData_IN_Source = chartData.GetLineChartData(pointsdata, titleIN, parameterIN, seriesNameTP_IN, colorMain, markerEnable, null, null);
                masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(pointsdataMovAverage, titleIN, parameterIN, seriesNameTPAver_IN, colorMain, markerEnable, chartZones.plotbands, chartZones.plotlines);
                masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(pointsdataTg, titleIN, parameterIN, seriesNameTPTg_IN, colorMain, markerEnable, null, null);
                masterModel.LineChartData_IN_Result = chartData.GetLineChartData(pointsdataResult, titleIN, parameterIN, seriesNameFP_IN, colorFind, markerEnable2, null, null);

                // выходной сигнал
                masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(pointsdataOUT, titleOUT, parameterOUT, seriesNameTP_OUT, colorMain, markerEnable, null, null);
                masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(pointsdataOUTMovAverage, titleOUT, parameterOUT, seriesNameTPAver_OUT, colorMain, markerEnable, chartZones_OUT.plotbands, chartZones_OUT.plotlines);
                masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(pointsdataOUTTg, titleOUT, parameterOUT, seriesNameTPTg_OUT, colorMain, markerEnable, null, null);
                masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(pointsdataResult_OUT, titleOUT, parameterOUT, seriesNameFP_OUT, colorFind, markerEnable2, null, null);

                return View(masterModel);
            }

            //if (masterModel.ProcessType == "Сохранить результаты")
            //{
            //}

            return View();
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
